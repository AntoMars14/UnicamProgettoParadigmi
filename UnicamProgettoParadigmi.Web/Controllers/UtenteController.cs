using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using UnicamProgettoParadigmi.Application.Abstractions;
using UnicamProgettoParadigmi.Application.Models.Dtos;

namespace UnicamProgettoParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        IUtenteService _utenteService;
        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost("registrazione")]
        public IActionResult Registrazione( UtenteDto utenteDto)
        {
            var response = _utenteService.Registrati(utenteDto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var response = _utenteService.Login(email, password);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
            
        }
    }
}
