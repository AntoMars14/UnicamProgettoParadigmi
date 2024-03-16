using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnicamProgettoParadigmi.Models.Context;
using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Models.Repositories
{
    public class ListaDistribuzioneEmailRepository : GenericRepository<ListaDistribuzioneEmail>
    {
        public ListaDistribuzioneEmailRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public List<Email> GetDestinatari(int idListaDistribuzione)
        {
            return this._ctx.ListaDistribuzioneEmail.Where(x => x.IdListaDistribuzione == idListaDistribuzione).Join(this._ctx.Emails, x => x.IdEmail, y => y.IdEmail, (x, y) => y).ToList();
        }

        public bool EmailContained(Email email)
        {
            return this._ctx.ListaDistribuzioneEmail.Where(x => x.IdEmail == email.IdEmail).Any();
        }


        public ListaDistribuzioneEmail? Get(int idListaDistribuzione, int idEmail)
        {
            return this._ctx.ListaDistribuzioneEmail.Where(x => x.IdListaDistribuzione == idListaDistribuzione && x.IdEmail == idEmail).FirstOrDefault();
        }

        public void Delete(int idListaDistribuzione, int idEmail)
        {
            var entity = Get(idListaDistribuzione, idEmail);
            if (entity != null)
            this._ctx.ListaDistribuzioneEmail.Remove(entity);
        }


        public List<ListaDistribuzione> GetListeUtente(int from, int num, string email, out int totalNum, int id)
        {
            Email? e = _ctx.Emails.Where(w => w.Destinatario == email).FirstOrDefault();
            if (e == null)
            {
                totalNum = 0;
                return new List<ListaDistribuzione>();
            }
            var query = _ctx.ListaDistribuzioneEmail.AsQueryable();
            query = query.Where(w => w.IdEmail == e.IdEmail);
            var query2 = _ctx.ListeDistribuzione.AsQueryable();
            query2 = query2.Where(w => w.Proprietario.IdUtente == id);
            query2 = query2.Join(query, x => x.IdListaDistribuzione, y => y.IdListaDistribuzione, (x, y) => x);

            totalNum = query2.Count();

            return
                query2
                .OrderBy(o => o.Nome)
                .Skip(from)
                .Take(num)
                .ToList();
        }
    }
}
