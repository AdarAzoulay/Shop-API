using Shop.Data.Models;
using Shop.Data.ViewMidels;

namespace Shop.Data.Services
{
    public class CustomersService
    {
        private AppDbContext _context;
        public CustomersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(CustomerVM customer)
        {
            var _customer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Age = customer.Age,
                DateCreated = DateTime.Now,
            };
            _context.Add(_customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.CustomerId == id);
        }

        public Customer UpdateCustomerById(int customerId, CustomerVM customer)
        {
            var _customer = _context.Customers.FirstOrDefault(c=>c.CustomerId==customerId);
            if(_customer != null)
            {
                _customer.FirstName = customer.FirstName;
                _customer.LastName = customer.LastName;
                _customer.Email = customer.Email;
                _customer.Age = customer.Age;
                _customer.DateCreated = DateTime.Now;

                _context.SaveChanges();
            }
            return _customer;
        }

        public void DeleteCustomer(int customerId)
        {
            var _customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (_customer != null)
            {
                _context.Customers.Remove(_customer);
                _context.SaveChanges();
            }
        }
    }
}
