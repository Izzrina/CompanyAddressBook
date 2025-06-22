namespace CompanyAddressBook.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an address with a phone number already exists
    /// Uses the error code "DUPLICA
    /// </summary>
    public class DuplicatePhoneException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePhoneException"/> class with the specified name.
        /// </summary>
        /// <param name="phone">The phone number that caused the duplication.</param>
        public DuplicatePhoneException(string phone)
            : base($"An address entry with the phone number '{phone}' already exists.", "DUPLICATE_PHONE")
        {
            Phone = phone;
        }

        /// <summary>
        /// Gets the phone number that caused the duplication.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// Gets a localized, user-friendly error message describing the duplication in a readable format.
        /// </summary>
        public override string UserMessage =>
            $"Ein Addresseintrag mit der Telefonnummer {Phone} existiert bereits.";
    }
}
