using Azure.Identity;
using Castle.Core.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using UnicamProgettoParadigmi.Application.Abstractions;
using UnicamProgettoParadigmi.Application.Factories;
using UnicamProgettoParadigmi.Application.Models.Responses;
using UnicamProgettoParadigmi.Application.Options;
using UnicamProgettoParadigmi.Models.Entities;
using UnicamProgettoParadigmi.Models.Repositories;

namespace UnicamProgettoParadigmi.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOption _emailOption;
        private readonly ListaDistribuzioneEmailRepository _listaDistribuzioneEmailRepository;
        private readonly ListaDistribuzioneRepository _listaDistribuzioneRepository;

        public EmailService(IOptions<EmailOption> emailOptions, ListaDistribuzioneEmailRepository listaDistribuzioneEmailRepository, ListaDistribuzioneRepository listaDistribuzioneRepository)
        {
            _emailOption = emailOptions.Value;
            _listaDistribuzioneEmailRepository = listaDistribuzioneEmailRepository;
            _listaDistribuzioneRepository = listaDistribuzioneRepository;
        }

        public async Task<BaseResponse<string>> SendEmailAsync(string subject, string body, List<FileAttachment> attachments, string NomeLista, int idUtente)
        {
            var lista = _listaDistribuzioneRepository.GetByNameAndOwner(NomeLista, idUtente);
            if (lista == null) return ResponseFactory.WithError("Lista non esistente tra quelle di cui sei proprietario");
            List<Recipient> recipients = new List<Recipient>();
            List<Email> destinatari = _listaDistribuzioneEmailRepository.GetDestinatari(lista.IdListaDistribuzione);
            foreach (var to in destinatari)
            {
                var recipient = new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = to.Destinatario
                    }
                };
                recipients.Add(recipient);
            }


            var clientCredential = new ClientSecretCredential(_emailOption.TenantId
                , _emailOption.ClientId
                , _emailOption.ClientSecret
                );
            var client = new GraphServiceClient(clientCredential);

            Message message = new()
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = Microsoft.Graph.Models.BodyType.Text,
                    Content = body
                },
                ToRecipients = recipients
            };

            if (!attachments.IsNullOrEmpty())
            {
                List<Attachment> atts = new List<Attachment>();
                foreach (var att in attachments)
                {
                    atts.Add(att);
                }
                message.Attachments = atts;
            }

            var postRequestBody = new SendMailPostRequestBody();
            postRequestBody.Message = message;
            postRequestBody.SaveToSentItems = true;


            await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);
            return ResponseFactory.WithSuccess("Email inviata");

        }
    }
}
