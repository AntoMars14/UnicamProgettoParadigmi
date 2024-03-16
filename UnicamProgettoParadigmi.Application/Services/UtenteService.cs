using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnicamProgettoParadigmi.Application.Abstractions;
using UnicamProgettoParadigmi.Application.Factories;
using UnicamProgettoParadigmi.Application.Models.Dtos;
using UnicamProgettoParadigmi.Application.Models.Responses;
using UnicamProgettoParadigmi.Application.Options;
using UnicamProgettoParadigmi.Models.Entities;
using UnicamProgettoParadigmi.Models.Repositories;

namespace UnicamProgettoParadigmi.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAuthenticationOption;

        public UtenteService(UtenteRepository userRepository, IOptions<JwtAuthenticationOption> jwtAuthOption)
        {
            _utenteRepository = userRepository;
            _jwtAuthenticationOption = jwtAuthOption.Value;
        }
        public BaseResponse<string> Registrati(UtenteDto utenteDto)
        {
            if(_utenteRepository.EmailTaken(utenteDto.Email))
            {
                return ResponseFactory.WithError("Email già in uso");
            }
            var utente = new Utente();
            utente.EmailUtente = utenteDto.Email;
            utente.Nome = utenteDto.Nome;
            utente.Cognome = utenteDto.Cognome;
            utente.Password = utenteDto.Password;
            this._utenteRepository.Add(utente);
            this._utenteRepository.Save();
            return ResponseFactory.WithSuccess("Utente registrato");
        }

        
        public BaseResponse<string> Login(string username, string password)
        {
            var utente = _utenteRepository.GetUtente(username, password);
            if(utente == null)
            {
                return ResponseFactory.WithError<string>("Credenziali errate");
            }
            List<Claim> claims = GetClaim(utente);
            var securityKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_jwtAuthenticationOption.Key)
           );
            var credentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(_jwtAuthenticationOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return ResponseFactory.WithSuccess(token);
        }

        private List<Claim> GetClaim(Utente utente)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("IdUtente", utente.IdUtente.ToString()),
                new Claim("EmailUtente", utente.EmailUtente),
                new Claim("Nome", utente.Nome),
                new Claim("Cognome", utente.Cognome)
            };
            return claims;
        }

    }
}
