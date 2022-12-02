namespace Backend.Dto
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string? ReturnDate { get; set; }
        public string Status { get; set; }
        public string PersonName { get; set; }
        public string ThingName { get; set; }
    }
}
