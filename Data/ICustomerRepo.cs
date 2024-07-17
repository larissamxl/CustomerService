using CustomerService.Model;

namespace CustomerService.Data
{
    public interface ICustomerRepo
    {
        bool SaveChanges();
        IEnumerable<Customer> GetAll();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
    }
}
