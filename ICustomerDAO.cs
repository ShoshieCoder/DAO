using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poco
{
    public interface ICustomerDAO
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int Id);
        void AddCustomer(Customer e);
        void UpdateCustomer(int Id, Customer e);
        void DeleteCustomer(int Id);
        List<Customer> GetCustomersLivingInCity(string City);
        List<Customer> GetCustomersBetweenAges(int minAge, int maxAge);
        Customer GetCustomerByPhoneNumber(string PHnumber);
        void RemoveAllCustomers();
    }
}
