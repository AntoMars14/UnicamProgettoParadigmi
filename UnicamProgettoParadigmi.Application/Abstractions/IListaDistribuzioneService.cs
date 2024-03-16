using UnicamProgettoParadigmi.Application.Models.Dtos;
using UnicamProgettoParadigmi.Application.Models.Responses;
using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Application.Abstractions
{
    public interface IListaDistribuzioneService
    {
        public BaseResponse<string> CreaListaDistribuzione(ListaDistribuzioneDto listaDistribuzioneDto, int id);
        public BaseResponse<string> AggiungiDestinatarioListaDistribuzione(string nomeLista, string email, int id);
        public BaseResponse<string> EliminaDestinatarioListaDistribuzione(string nomeLista, string email, int id);
        public List<ListaDistribuzione> GetListeUtente(int from, int num, string email, out int totalNum, int id);

    }
}
