namespace Customer.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
