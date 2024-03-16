using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamProgettoParadigmi.Models.Entities
{
    public class ListaDistribuzione
    {
        public int IdListaDistribuzione { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int IdProprietario { get; set; }
        public virtual Utente Proprietario { get; set; } = null!;
    }
}
