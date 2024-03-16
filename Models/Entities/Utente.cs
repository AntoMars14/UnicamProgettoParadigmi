namespace UnicamProgettoParadigmi.Models.Entities
{
    public class Utente
    {
        public int IdUtente { get; set; }
        public string EmailUtente { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual ICollection<ListaDistribuzione> ListeDistribuzione { get; set; } = new List<ListaDistribuzione>();

    }
}
