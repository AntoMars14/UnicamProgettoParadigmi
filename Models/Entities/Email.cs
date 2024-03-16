using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamProgettoParadigmi.Models.Entities
{
    public class Email
    {
        public int IdEmail { get; set; }
        public string Destinatario { get; set; } = string.Empty;
    }
}
