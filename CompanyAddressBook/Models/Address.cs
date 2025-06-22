using System;

namespace CompanyAddressBook.Models
{
    /// <summary>
    /// Represents an address, inheriting from the <see cref="Person"/> class.
    /// </summary>
    internal class Address : Person
    {
        /// <summary>
        /// Gets or sets the street address, including house number.
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the phone number associated with the address.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class with the specified person and address details.
        /// </summary>
        /// <param name="firstName">The person's first name.</param>
        /// <param name="lastName">The person's last name.</param>
        /// <param name="street">The street address including house number.</param>
        /// <param name="city">The city.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="phoneNumber">The phone number.</param>
        public Address(string firstName, string lastName, string street, string city, string postalCode, string phoneNumber) : base(firstName, lastName)

        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Displays the full address information to the console.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"{FirstName} {LastName}");
            Console.WriteLine($"{Street}");
            Console.WriteLine($"{PostalCode} {City}");
            Console.WriteLine($"Phone: {PhoneNumber}");
        }
    }
}
