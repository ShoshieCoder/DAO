using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace poco
{
    public class CustomerDAO : ICustomerDAO
    {
        public static SQLiteConnection con;
        public static string dbName = @"C:\Users\Sahar PC\sqlDB\Customer.db";

        static CustomerDAO()
        {
            con = new SQLiteConnection($"Data Source = {dbName}; Version=3;");
            con.Open();
        }

        public static void Close()
        {
            con.Close();
        }

        public void CreateTable()
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"CREATE TABLE 'CUSTOMER' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "'FIRST_NAME'    TEXT NOT NULL," +
                    "'LAST_NAME' TEXT NOT NULL," +
                    "'AGE'   INTEGER NOT NULL," +
                    "'ADDRESS_CITY'  TEXT," +
                    "'ADDRESS_STREET'    TEXT," +
                    "'PH_NUMBER' TEXT UNIQUE)", con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCustomer(Customer e)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO CUSTOMER(FIRST_NAME, LAST_NAME, AGE, ADDRESS_CITY," +
                $"ADDRESS_STREET, PH_NUMBER) VALUES ('{e.FirstName}',"+
                $"'{e.LastName}', '{e.Age}', '{e.AddressCity}', '{e.AddressStreet}', '{e.PHnumber}')", con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int Id)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM CUSTOMER WHERE ID = {Id}", con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAllCustomers()
        {

            List<Customer> customers = new List<Customer>();

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * From CUSTOMER", con))
            {

                 using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Customer e = new Customer
                            {
                                Id = (Int64)reader["ID"],
                                FirstName = (string)reader["FIRST_NAME"],
                                LastName = (string)reader["LAST_NAME"],
                                Age = (Int64)reader["AGE"],
                                AddressCity = (string)reader["ADDRESS_CITY"],
                                AddressStreet = (string)reader["ADDRESS_STREET"],
                                PHnumber = (string)reader["PH_NUMBER"]
                            };

                            customers.Add(e);
                        }
                    }
                }
                return customers;
            }
        
        public Customer GetCustomerById(int Id)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM CUSTOMER WHERE ID = {Id}", con))
            {

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read() == true)
                    {

                        Customer e = new Customer
                        {
                            Id = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = (Int64)reader["AGE"],
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PHnumber = (string)reader["PH_NUMBER"]
                        };

                        return e;
                    }

                }
            }

            return null;
        }

        public Customer GetCustomerByPhoneNumber(string PHnumber)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM CUSTOMER WHERE PH_NUMBER = {PHnumber}", con))
            {

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read() == true)
                    {

                        Customer e = new Customer
                        {
                            Id = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = (Int64)reader["AGE"],
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PHnumber = (string)reader["PH_NUMBER"]
                        };

                        return e;
                    }

                }
            }

            return null;
        }

        public Customer GetCustomerByPhoneNumberLINQ(string PHnumber)
        {
            //.FirstOrDefault() - returns the first elemnt that satisfies the condition or a default value (null)

            List<Customer> Customers = GetAllCustomers();

            var qCustomer = (from c in Customers
                            where c.PHnumber == PHnumber
                            select c).ToList();

            //var mCustomer = Customers.Where((c => c.PHnumber == PHnumber).FirstOrDefault().ToList());

            return qCustomer.FirstOrDefault();
        }


        public List<Customer> GetCustomersBetweenAges(int minAge, int maxAge)
        {
            List<Customer> customers = new List<Customer>();

            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * From CUSTOMER WHERE AGE BETWEEN {minAge} and {maxAge}", con))
            {

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Customer e = new Customer
                        {
                            Id = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = (Int64)reader["AGE"],
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PHnumber = (string)reader["PH_NUMBER"]
                        };

                        customers.Add(e);
                    }
                }
            }
            return customers;
        }

        public List<Customer> GetCustomersLivingInCity(string City)
        {
            List<Customer> customers = new List<Customer>();

            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * From CUSTOMER WHERE ADDRESS_CITY = '{City}'", con))
            {

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Customer e = new Customer
                        {
                            Id = (Int64)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = (Int64)reader["AGE"],
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PHnumber = (string)reader["PH_NUMBER"]
                        };

                        customers.Add(e);
                    }
                }
            }
            return customers;
        }

        public void RemoveAllCustomers()
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM CUSTOMER", con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(int Id, Customer e)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"UPDATE CUSTOMER SET ID = {e.Id}, FIRST_NAME={e.FirstName}," +
            $"LAST_NAME={e.LastName}, AGE={e.Age}, ADDRESS_CITY={e.AddressCity}, ADDRESS_STREET={e.AddressStreet}" +
            $"PH_NUMBER={e.PHnumber} WHERE ID ={Id}", con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
    }

