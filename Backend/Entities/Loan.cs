namespace Backend.Entities
{
    public class Loan : EntityBase
    {
        public DateTime Date { get; set; }  
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
        public Thing Thing { get; set; }
        public Person Person { get; set; }


    }
}
