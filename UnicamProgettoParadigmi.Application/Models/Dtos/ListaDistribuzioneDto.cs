using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Application.Models.Dtos
{
    public class ListaDistribuzioneDto
    {
        public ListaDistribuzioneDto() { }

        public ListaDistribuzioneDto(ListaDistribuzione lista)
        {
            Nome = lista.Nome;
        }
        public string Nome { get; set; } = string.Empty;
    }
}
