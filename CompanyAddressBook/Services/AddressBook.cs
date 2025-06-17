using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAddressBook.Models;
using CompanyAddressBook.Interfaces;
using CompanyAddressBook.Utils;

namespace CompanyAddressBook.Services
{
    internal class AddressBook : IAddressbook

    {
        private const string Filepath = "Data/AddressList.json";
        private  List<Address> _addresses = new List<Address>();

        // Im Konstruktor wird die direkt die Liste mit den Namen aus der Jsondatei geladen
        public AddressBook()
        {
            _addresses = JsonUtils.LoadDataFromJson<Address>(Filepath);
        }

        public Address AddAddress()
        {
            Console.WriteLine(" ");
            return new Address();
        }

        public void RemoveAddress(Address address)
        {
            Console.WriteLine(address.ToString());
        }

        public Address FindAddressByPhoneNumber(string phone)
        {
            return new Address();
        }

        public List<Address> FindAddressByLastName(string lastName)
        {
            return new List<Address>();
        }
    }
}
