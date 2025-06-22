namespace CompanyAddressBook.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when saving data to a file fails.
    /// </summary>
    internal class SaveFailedException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFailedException"/> class with the specified filepath.
        /// </summary>
        /// <param name="filePath">The file path to which the save operation failed.</param>
        public SaveFailedException(string filePath)
      : base($"Failed to save data to file '{filePath}'.", "SAVE_FAILED")
        {
            FilePath = filePath;
        }
        /// <summary>
        /// Gets the file path involved in the failed save operation.
        /// </summary>
        public string FilePath { get; }
        /// <summary>
        /// Gets a localized, user-friendly error message describing the failure of saving the data in a readable format.
        /// </summary>
        public override string UserMessage =>
            $"Speichern der Änderung in '{FilePath}' ist fehlgeschlagen.";
    }

}
