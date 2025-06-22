namespace CompanyAddressBook.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an address entry with the combination of a specific firstname and lastname already exists.
    /// /// Uses the error code <c>DUPLICATE_NAME</c>.
    /// </summary>
    public class DuplicateNameException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNameException"/> class with the specified name.
        /// </summary>
        /// <param name="firstName">The first name of the duplicate name.</param>
        /// <param name="lastName">The last name of the duplicate name.</param>
        public DuplicateNameException(string firstName, string lastName)
               : base($"An address entry with the same name already exists.", "DUPLICATE_NAME")
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets the firstname of the ducplicate name.
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// Gets the lastname of the duplicate name.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets a localized, user-friendly error message describing the duplication in a readable format.
        /// </summary>
        public override string UserMessage =>
            $"Ein Adresseintrag für {FirstName} {LastName} ist bereits vorhanden.";
    }

}
