using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAddressBook.Models;

namespace CompanyAddressBook.Interfaces
{
    internal interface IAddressbook
    {
        Address AddAddress();

        void RemoveAddress(Address address);

        Address FindAddressByPhoneNumber(string phone);

        List<Address> FindAddressByLastName(string lastName);
    }
}
