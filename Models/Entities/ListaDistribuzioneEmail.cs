using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamProgettoParadigmi.Models.Entities
{
    public class ListaDistribuzioneEmail
    {
        public int  IdListaDistribuzione { get; set; }
        public int IdEmail { get; set; }

        public ListaDistribuzioneEmail(int idListaDistribuzione, int idEmail)
        {
            IdListaDistribuzione = idListaDistribuzione;
            IdEmail = idEmail;
        }
    }
}
