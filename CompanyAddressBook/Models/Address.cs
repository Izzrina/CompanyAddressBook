using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAddressBook.Models
{
    internal class Address : Person
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{FirstName} {LastName}");
            Console.WriteLine($"{Street}");
            Console.WriteLine($"{PostalCode} {City}");
            Console.WriteLine($"Phone: {PhoneNumber}");
        }
    }
}
