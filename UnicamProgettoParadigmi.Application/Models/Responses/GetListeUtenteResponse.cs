using UnicamProgettoParadigmi.Application.Models.Dtos;

namespace UnicamProgettoParadigmi.Application.Models.Responses
{
    public class GetListeUtenteResponse
    {
        public List<ListaDistribuzioneDto> Liste { get; set; } = new List<ListaDistribuzioneDto>();
        public int NumeroPagine { get; set; }
    }
}
