using CompanyAddressBook.Exceptions;
using CompanyAddressBook.Interfaces;
using CompanyAddressBook.Models;
using CompanyAddressBook.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyAddressBook.Services
{
    internal class AddressBook : IAddressbook

    {
        private const string FilePath = "Data/AddressList.json";
        private List<Address> _addresses = new List<Address>();


        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class and loads address data from a JSON file defined by <see cref="FilePath"/>.
        /// </summary>
        /// <remarks>
        /// The loaded data is stored in the <see cref="_addresses"/> field. 
        /// If the JSON file does not exist or cannot be read, <see cref="_addresses"/> will be initialized as an empty list.
        /// </remarks>
        public AddressBook()
        {
            _addresses = JsonUtils.LoadDataFromJson<Address>(FilePath);
        }

        /// <summary>
        /// Shows all addresses currently in the list<see cref="_addresses"/>
        /// </summary>
        public void ShowAllAddresses()
        {
            foreach (var address in _addresses)
            {
                Console.WriteLine();
                address.DisplayInfo();
            }
        }

        /// <summary>
        /// Adds a new address to the the <see cref="_addresses"/> field after checking for duplicates and saves the updated list to a JSON file defined by <see cref="FilePath".
        /// </summary>
        /// <param name="address">The <see cref="Address"/> object to be added.</param>
        /// <exception cref="DuplicatePhoneException">
        /// Thrown when the phone number of the address is already in use.
        /// </exception>
        /// <exception cref="DuplicateNameException">
        /// Thrown when an address with the same first and last name already exists.
        /// </exception>
        /// <exception cref="SaveFailedException">
        /// Thrown when saving the updated address list to the JSON file fails.
        /// </exception>
        /// <remarks>
        /// If the save operation fails after adding the new address, the address is removed from the list to maintain data integrity.
        /// </remarks>
        public void AddAddress(Address address)
        {   //check if phone number is already in use
            if (_addresses.Any(a => a.PhoneNumber == address.PhoneNumber))
            {
                throw new DuplicatePhoneException(address.PhoneNumber);
            }
            // check if someone with the the same name is already registered
            if (_addresses.Any(a => a.FirstName == address.FirstName && a.LastName == address.LastName))
            {
                throw new DuplicateNameException(address.FirstName, address.LastName);
            }
            _addresses.Add(address);

            bool saved = JsonUtils.SaveDataToJson(_addresses, FilePath);

            // if saving fails remove address from list to keep consistency
            if (!saved)
            {
                _addresses.Remove(address);
                throw new SaveFailedException(FilePath);
            }
        }

        /// <summary>
        /// Searches the address list <see cref="_addresses"/> for a contact that matches the given first and last name (case-insensitive).
        /// </summary>
        /// <param name="firstName">The first name of the contact to search for.</param>
        /// <param name="lastName">The last name of the contact to search for.</param>
        /// <returns>
        /// The <see cref="Address"/> object that matches the given name, or <c>null</c> if no match is found.
        /// </returns>
        /// <remarks>
        /// This method uses case-insensitive comparison for both the first and last name.
        /// If no matching address is found, the method returns <c>null</c>.
        /// </remarks>
        public Address FindAddress(string firstName, string lastName)
        {
            var address = _addresses.FirstOrDefault(a => a.FirstName?.ToLower() == firstName?.ToLower() && a.LastName?.ToLower() == lastName?.ToLower());
            if (address == null)
            {
                throw new AddressNotFoundException(firstName, lastName);
            }
            return address;
        }

        /// <summary>
        /// Removes an <see cref="Address"/> from the <see cref="_addresses"/> list after verifying its existence
        /// using the <see cref="FindAddress(string, string)"/> method, and saves the updated list to the JSON file defined by <see cref="FilePath"/>.
        /// </summary>
        /// <param name="address">The <see cref="Address"/> object to be removed from the address list</param>
        /// <exception cref="AddressNotFoundException">
        /// Thrown if no address entry with the given first and last name is found (case-insensitive)
        /// </exception>
        /// /// <remarks>
        /// This method uses case-insensitive comparison for both the first and last name
        /// </remarks>
        public void RemoveAddress(Address address)
        {
            var existingAddress = _addresses.FirstOrDefault(a =>
                a.FirstName == address.FirstName && a.LastName == address.LastName);

            if (existingAddress == null)
            {
                throw new AddressNotFoundException(address.FirstName, address.LastName);
            }

            _addresses.Remove(existingAddress);

            bool saved = JsonUtils.SaveDataToJson(_addresses, FilePath);
            // if saving fails remove address from list to keep consistency
            if (!saved)
            {
                _addresses.Add(existingAddress);
                throw new SaveFailedException(FilePath);
            }
        }
    }
}
