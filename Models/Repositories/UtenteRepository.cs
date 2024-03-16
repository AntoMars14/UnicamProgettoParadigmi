using UnicamProgettoParadigmi.Models.Context;
using UnicamProgettoParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamProgettoParadigmi.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public Utente? GetUtente(string email, string password)
        {
            return this._ctx.Utenti.Where(x => x.EmailUtente.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
        }

        public bool EmailTaken(string email)
        {
            return this._ctx.Utenti.Where(x => x.EmailUtente.Equals(email)).Any();
        }
    }
}
