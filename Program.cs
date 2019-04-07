using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poco
{
    class Program
    {
        static void Main(string[] args)
        {


            CustomerDAO dao = new CustomerDAO();
            /*
            //dao.CreateTable();
            Customer c = new Customer
            {
                FirstName = "Ronen",
                LastName = "Haim",
                Age = 33,
                AddressCity = "Rishon le zion",
                AddressStreet = "Hertzel",
                PHnumber = "03-9644196"
            };

            dao.AddCustomer(c);
            */


            List<Customer> customers = dao.GetAllCustomers();
            

            Customer c3 = dao.GetCustomerByPhoneNumber("03-9644196");

            List<Customer> customersAges = dao.GetCustomersBetweenAges(30, 35);

            List<Customer> customersCity = dao.GetCustomersLivingInCity("Rishon le zion");

            List<Customer> customers2 = dao.GetAllCustomers();

            CustomerDAO.Close();



        }
    }
}
