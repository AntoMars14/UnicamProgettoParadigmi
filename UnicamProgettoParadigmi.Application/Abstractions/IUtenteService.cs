using UnicamProgettoParadigmi.Application.Models.Dtos;
using UnicamProgettoParadigmi.Application.Models.Responses;

namespace UnicamProgettoParadigmi.Application.Abstractions
{
    public interface IUtenteService
    {
        public BaseResponse<string> Registrati(UtenteDto utenteDto);
        public BaseResponse<string> Login(string username, string password);
    }
}
