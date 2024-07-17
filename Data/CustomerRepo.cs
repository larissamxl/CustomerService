using CustomerService.Model;

namespace CustomerService.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _context;

        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            _context.Customers.Add(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
