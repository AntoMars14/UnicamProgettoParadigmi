using Castle.Core.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Application.Models.Dtos
{
    public class ListaDistribuzioneDto
    {
        public ListaDistribuzioneDto() { }

        public ListaDistribuzioneDto(ListaDistribuzione lista)
        {
            Nome = lista.Nome;
            Emails = null;
        }
        public string Nome { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Emails { get; set; } = new List<string>();
    }
}
