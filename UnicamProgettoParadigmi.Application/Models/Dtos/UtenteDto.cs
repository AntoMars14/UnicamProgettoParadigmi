namespace UnicamProgettoParadigmi.Application.Models.Dtos
{
    public class UtenteDto
    {
        public UtenteDto() { }
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
