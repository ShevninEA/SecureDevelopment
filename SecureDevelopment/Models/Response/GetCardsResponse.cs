namespace SecureDevelopment.Models.Response
{
    public class GetCardsResponse
    {
        public IList<CardDto> Cards { get; set; }
        public int ErrorCode { get; set; }
        public int ErrorMessage { get; set; }
    }
}
