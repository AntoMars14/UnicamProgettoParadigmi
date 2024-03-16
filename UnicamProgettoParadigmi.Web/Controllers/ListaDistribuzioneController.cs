using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Security.Claims;
using UnicamProgettoParadigmi.Application.Abstractions;
using UnicamProgettoParadigmi.Application.Factories;
using UnicamProgettoParadigmi.Application.Models.Dtos;
using UnicamProgettoParadigmi.Application.Models.Requests;
using UnicamProgettoParadigmi.Application.Models.Responses;

namespace UnicamProgettoParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        private readonly IEmailService _emailService;
        public ListaDistribuzioneController(IListaDistribuzioneService listaDistribuzioneService, IEmailService emailService)
        {
            _listaDistribuzioneService = listaDistribuzioneService;
            _emailService = emailService;
        }

        [HttpPost("creaLista")]
        public IActionResult CreaLista(ListaDistribuzioneDto listaDistribuzioneDto)
        {
            int? id = GetUtenteId();
            if(id == null)
            {
                return Unauthorized();
            }
            var response = _listaDistribuzioneService.CreaListaDistribuzione(listaDistribuzioneDto, id ?? 0);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut("aggiungiDestinatario")]
        public IActionResult AggiungiDestinatario(EmailOperationDto emailOperationDto)
        {
            int? id = GetUtenteId();
            if(id == null)
            {
                return Unauthorized();
            }
            var response = _listaDistribuzioneService.AggiungiDestinatarioListaDistribuzione(emailOperationDto.NomeLista, emailOperationDto.Email, id ?? 0);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("eliminaDestinatario")]
        public IActionResult EliminaDestinatario(EmailOperationDto emailOperationDto)
        {
            int? id = GetUtenteId();
            if (id == null)
            {
                return Unauthorized();
            }
            var response = _listaDistribuzioneService.EliminaDestinatarioListaDistribuzione(emailOperationDto.NomeLista, emailOperationDto.Email, id ?? 0);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("inviaEmail")]
        public IActionResult InviaEmail(string subject, string body, List<IFormFile> attachments, string nomeLista)
        {
            List<FileAttachment> atts = new List<FileAttachment>();
            foreach (var f in attachments)
            {
                var file = f.OpenReadStream();
                var att = new FileAttachment();
                att.Name = f.FileName;
                att.ContentBytes = new BinaryReader(file).ReadBytes((int)file.Length);
                atts.Add(att);
            }
            int? id = GetUtenteId();
            if (id == null)
            {
                return Unauthorized();
            }
            var response = _emailService.SendEmailAsync(subject, body, atts, nomeLista, id ?? 0);
            if (response.Result.Success)
            {
                return Ok(response.Result);
            } else
            {
                return BadRequest(response.Result);
            }
        }


        [HttpPost("listeUtente")]
        public IActionResult ListeUtente(GetListeUtenteRequest request)
        {
            int? id = GetUtenteId();
            if (id == null)
            {
                return Unauthorized();
            }
            int totalNum = 0;
            var liste = _listaDistribuzioneService.GetListeUtente((request.PageNumber-1) * request.PageSize, request.PageSize, request.Email, out totalNum, id ?? 0);

            var response = new GetListeUtenteResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Liste = liste.Select(s =>
            new ListaDistribuzioneDto(s)).ToList();

            if(totalNum == 0)
            {
                return NotFound(ResponseFactory
                                       .WithError("Email non presente in nessuna lista di cui sei proprietario"));
            }
            return Ok(ResponseFactory
              .WithSuccess(response)
              );
        }
        private int? GetUtenteId()
        {
            var identity = this.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var utenteIdClaim = identity.Claims.Where(c => c.Type == "IdUtente").First();
                if (utenteIdClaim != null)
                {
                    return int.Parse(utenteIdClaim.Value);
                }
            }
            return null;
        }

    }
}
