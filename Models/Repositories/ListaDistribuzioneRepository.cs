using UnicamProgettoParadigmi.Models.Context;
using UnicamProgettoParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamProgettoParadigmi.Models.Repositories
{
    public class ListaDistribuzioneRepository : GenericRepository<ListaDistribuzione>
    {
        public ListaDistribuzioneRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public Utente? GetProprietario(int idLista)
        {
            var lista = this._ctx.ListeDistribuzione.Where(x => x.IdListaDistribuzione.Equals(idLista)).FirstOrDefault();
            if (lista == null) return null;
            var id = lista.IdProprietario;
            return this._ctx.Utenti.Where(x => x.IdUtente.Equals(id)).FirstOrDefault();
        }

        public ListaDistribuzione? GetById(int idLista)
        {
            return this._ctx.ListeDistribuzione.Where(x => x.IdListaDistribuzione == idLista).FirstOrDefault();
        }
        
        public bool NameTaken(string name, Utente proprietario)
        {
            return this._ctx.ListeDistribuzione.Where(x => x.Nome.Equals(name) && x.IdProprietario == proprietario.IdUtente).Any();
        }

        public ListaDistribuzione? GetByNameAndOwner(string name, int proprietarioId)
        {
            return this._ctx.ListeDistribuzione.Where(x => x.Nome.Equals(name) && x.IdProprietario == proprietarioId).FirstOrDefault();
        }
    }
}
