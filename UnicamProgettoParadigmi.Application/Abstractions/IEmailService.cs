using Microsoft.Graph.Models;
using UnicamProgettoParadigmi.Application.Models.Responses;

namespace UnicamProgettoParadigmi.Application.Abstractions
{
    public interface IEmailService
    {
        Task<BaseResponse<string>> SendEmailAsync(string subject, string body, List<FileAttachment> attachments, string NomeList, int idUtente);
    }
}
