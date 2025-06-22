using CompanyAddressBook.Models;
using System.Collections.Generic;

namespace CompanyAddressBook.Interfaces
{
    /// <summary>
    /// Defines the contract for managing addresses in the company address book.
    /// </summary>
    internal interface IAddressbook
    {
        /// <summary>
        /// Displays all addresses in the address book.
        /// </summary>
        void ShowAllAddresses();

        /// <summary>
        /// Adds a new address to the address book.
        /// </summary>
        /// <param name="adress">The address to add.</param>
        void AddAddress(Address adress);

        /// <summary>
        /// Finds a single address based on first and last name.
        /// </summary>
        /// <param name="firstName">The first name to search for.</param>
        /// <param name="lastName">The last name to search for.</param>
        /// <returns>The matching <see cref="Address"/>, or null if not found.</returns>
        Address FindAddress(string firstName, string lastName);

        /// <summary>
        /// Removes an address from the address book.
        /// </summary>
        /// <param name="adress">The address to remove.</param>
        void RemoveAddress(Address adress);
    }
}
