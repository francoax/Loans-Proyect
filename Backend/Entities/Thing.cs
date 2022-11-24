namespace Backend.Entities
{
    public class Thing : EntityBase
    {
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public IList<Loan> Loans { get; set; }
        public DateTime CreationDate { get; set; }


    }
}
