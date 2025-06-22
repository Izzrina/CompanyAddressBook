namespace CompanyAddressBook.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an address with a given combination of firstname and lastname does not exists
    /// Uses the error code <c>ADDRESS_NOT_FOUND</c>
    /// </summary>
    public class AddressNotFoundException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressNotFoundException"/> with the specific name
        /// </summary>
        /// <param name="firstName">The firstname </param>
        /// <param name="lastName"></param>
        public AddressNotFoundException(string firstName, string lastName)
                     : base($"No address entry found for '{firstName} {lastName}'", "ADDRESS_NOT_FOUND")
        {
            FirstName = firstName;
            LastName = lastName;
        }
        /// <summary>
        /// Gets the firstname that caused the 
        /// </summary>
        public string FirstName { get; }
        public string LastName { get; }

        public override string UserMessage =>
            $"Kein Adresseintrag für {FirstName} {LastName} gefunden.";
    }
}
