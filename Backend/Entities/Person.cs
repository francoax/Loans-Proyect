namespace Backend.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IList<Loan> Loans { get; set; }
    }
}
