using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamProgettoParadigmi.Models.Context;
using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Models.Repositories
{
    public class EmailRepository : GenericRepository<Email>
    {
        public EmailRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public Email? GetByEmail(string email)
        {
            return this._ctx.Emails.Where(x => x.Destinatario == email).FirstOrDefault();
        }
    }
}
