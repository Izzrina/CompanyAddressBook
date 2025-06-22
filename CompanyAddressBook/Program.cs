using CompanyAddressBook.Services;
using CompanyAddressBook.Views;



namespace CompanyAddressBook
{
    internal class Program
    {
        /// <summary>
        /// Application entry point. Initializes the address book and starts the console user interface.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            var addressBook = new AddressBook();
            var ui = new ConsoleUI(addressBook);
            ui.ShowIntro();
            ui.RunMenu();
        }
    }
}
