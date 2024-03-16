namespace UnicamProgettoParadigmi.Application.Models.Requests
{
    public class GetListeUtenteRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Email { get; set; }

    }
}
