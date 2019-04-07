using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poco
{
    public class Customer
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 Age { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string PHnumber { get; set; }

        public override string ToString()
        {
            return $"Customer {Id} {FirstName} {LastName} {Age} {AddressCity} {AddressStreet} {PHnumber}";
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Customer other = obj as Customer;
            if (other == null)
                return false;

            return this.Id == other.Id;
        }
    }
}
