namespace Muresan_Cristian_Lab2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
