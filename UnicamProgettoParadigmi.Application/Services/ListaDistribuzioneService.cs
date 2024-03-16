using System;
using UnicamProgettoParadigmi.Application.Abstractions;
using UnicamProgettoParadigmi.Application.Factories;
using UnicamProgettoParadigmi.Application.Models.Dtos;
using UnicamProgettoParadigmi.Application.Models.Responses;
using UnicamProgettoParadigmi.Models.Entities;
using UnicamProgettoParadigmi.Models.Repositories;

namespace UnicamProgettoParadigmi.Application.Services
{
    public class ListaDistribuzioneService : IListaDistribuzioneService
    {
        private readonly ListaDistribuzioneRepository _listaDistribuzioneRepository;
        private readonly ListaDistribuzioneEmailRepository _listaDistribuzioneEmailRepository;
        private readonly EmailRepository _emailRepository;
        private readonly UtenteRepository _utenteRepository;

        public ListaDistribuzioneService(ListaDistribuzioneRepository listaDistribuzioneRepository, ListaDistribuzioneEmailRepository listaDistribuzioneEmailRepository, EmailRepository emailRepository, UtenteRepository utenteRepository)
        {
            _listaDistribuzioneRepository = listaDistribuzioneRepository;
            _listaDistribuzioneEmailRepository = listaDistribuzioneEmailRepository;
            _emailRepository = emailRepository;
            _utenteRepository = utenteRepository;
        }

        public BaseResponse<string> AggiungiDestinatarioListaDistribuzione(string nomeLista, string email, int id)
        {
            var lista = _listaDistribuzioneRepository.GetByNameAndOwner(nomeLista, id);
            if (lista == null) return ResponseFactory.WithError("Lista non esistente tra quelle di cui sei il proprietario");
            if (_listaDistribuzioneEmailRepository.GetDestinatari(lista.IdListaDistribuzione).Any(x => x.Destinatario.Equals(email)))
            {
                return ResponseFactory.WithError("Destinatario già presente");
            }
            Email? e = _emailRepository.GetByEmail(email);
            if (e == null)
            {
                _emailRepository.Add(new Email() { Destinatario = email });
                _emailRepository.Save();
            }
            _listaDistribuzioneEmailRepository.Add(new ListaDistribuzioneEmail(lista.IdListaDistribuzione, _emailRepository.GetByEmail(email).IdEmail));
            _listaDistribuzioneRepository.Save();
            return ResponseFactory.WithSuccess("Destinatario aggiunto");
        }

        public BaseResponse<string> CreaListaDistribuzione(ListaDistribuzioneDto listaDistribuzioneDto, int id)
        {
            var utente = _utenteRepository.Get(id);
            if(_listaDistribuzioneRepository.NameTaken(listaDistribuzioneDto.Nome, utente))
            {
                return ResponseFactory.WithError("Lista con questo nome di cui sei proprietario già esistente");
            }
            var lista = new ListaDistribuzione();
            lista.Nome = listaDistribuzioneDto.Nome;
            lista.Proprietario = utente;
            _listaDistribuzioneRepository.Add(lista);
            _listaDistribuzioneRepository.Save();
            utente.ListeDistribuzione.Add(lista);
            _utenteRepository.Save();
            return ResponseFactory.WithSuccess("Lista creata");
        }

        public BaseResponse<string> EliminaDestinatarioListaDistribuzione(string nomeLista, string email, int id)
        {
            var lista = _listaDistribuzioneRepository.GetByNameAndOwner(nomeLista, id);
            if (lista == null) return ResponseFactory.WithError("Lista non esistente tra quelle di cui sei il proprietario");
            if (!_listaDistribuzioneEmailRepository.GetDestinatari(lista.IdListaDistribuzione).Any(x => x.Destinatario.Equals(email)))
            {
                return ResponseFactory.WithError("Destinatario non presente");
            }
            Email e = _emailRepository.GetByEmail(email);
            _listaDistribuzioneEmailRepository.Delete(lista.IdListaDistribuzione, e.IdEmail);
            _listaDistribuzioneEmailRepository.Save();
            removeEmail(e);
            return ResponseFactory.WithSuccess("Destinatario rimosso");
        }

        private void removeEmail(Email email)
        {
            if (!_listaDistribuzioneEmailRepository.EmailContained(email))
            {
                _emailRepository.Delete(email.IdEmail);
                _emailRepository.Save();
            }
        }

        public List<ListaDistribuzione> GetListeUtente(int from, int num, string email, out int totalNum, int id)
        {
            return _listaDistribuzioneEmailRepository.GetListeUtente(from, num, email, out totalNum, id);
        }
    }
}
