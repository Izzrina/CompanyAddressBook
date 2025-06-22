using CompanyAddressBook.Exceptions;
using CompanyAddressBook.Interfaces;
using CompanyAddressBook.Models;
using CompanyAddressBook.Utils;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CompanyAddressBook.Views
{
    internal class ConsoleUI
    {
        private readonly IAddressbook _addressBook;

        public ConsoleUI(IAddressbook addressBook)
        {
            _addressBook = addressBook;
        }

        /// <summary>
        /// Displays the application introduction and usage instructions in the console.
        /// </summary>
        public void ShowIntro()
        {
            Console.Write("Willkommen im ");
            ConsoleTextColorizer.WriteColored("*** Firmen-Adressbuch! *** ", ConsoleColor.Blue);
            Console.WriteLine(" von Nadine Rabitsch");
            Console.WriteLine();
            Console.WriteLine("Dieses einfache Konsolenprogramm ermöglicht es Ihnen:");
            Console.WriteLine("- Neue Adressen hinzuzufügen");
            Console.WriteLine("- Bestehende Einträge zu bearbeiten");
            Console.WriteLine("- Adressen zu löschen");
            Console.WriteLine("- Kontakte schnell zu suchen und anzuzeigen");
            Console.WriteLine();
            Console.WriteLine("Verwenden Sie das Menü, um Ihre Firmenkontakte effizient zu verwalten.\n");
        }

        /// <summary>
        /// Runs the main menu loop of the application, displaying available actions and processing user input.
        /// </summary>
        /// <remarks>
        /// This method shows a menu with options to add, delete, search, or display addresses,
        /// as well as to exit the program. It continuously prompts the user until the program is terminated.
        /// </remarks>
        public void RunMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Verfügbare Aktionen =====");
                Console.WriteLine("Adresse hinzufügen (1)  Adresse löschen (2)  Adresse suchen (3)  Alle anzeigen (4)  Beenden (0)");
                Console.Write("Auswahl: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        CreateAddressFromInput();
                        break;
                    case "2":
                        Console.Clear();
                        DeleteAddress();
                        break;
                    case "3":
                        Console.Clear();
                        SearchAddressByName();
                        break;
                    case "4":
                        Console.Clear();
                        _addressBook.ShowAllAddresses();
                        break;
                    case "0":
                        //Console.Clear();
                        Console.WriteLine("Programm beendet. Auf Wiedersehen!");
                        Environment.Exit(0);
                        break;
                    default:
                        ConsoleTextColorizer.WriteColoredLine("Ungültige Eingabe", ConsoleColor.Yellow);
                        break;
                }
            }
        }
        /// <summary>
        /// Captures a new address through console input, validates the entries, and saves it in the address book.
        /// </summary>
        /// <remarks>
        /// The method prompts the user to enter first name, last name, street, city, postal code, and phone number.
        /// Each input is validated for correctness.
        /// After entering the data, the address is displayed and the user is asked whether to save it.
        /// </remarks>
        public void CreateAddressFromInput()
        {
            string firstName, lastName, street, city, postalCode, phoneNumber;

            do
            {
                Console.Write("Vorname: ");
                firstName = Console.ReadLine()?.Trim(); // Null-Conditional Operator
                if (string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsDigit))
                {
                    ConsoleTextColorizer.WriteColoredLine("Der Vorname darf nicht leer sein und keine Zahlen enthalten. Bitte erneut eingeben.", ConsoleColor.Yellow);
                    firstName = null;
                }
            } while (string.IsNullOrWhiteSpace(firstName));

            do
            {
                Console.Write("Nachname: ");
                lastName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsDigit))
                {
                    ConsoleTextColorizer.WriteColoredLine("Der Nachname darf nicht leer sein und keine Zahlen enthalten.", ConsoleColor.Yellow);
                    lastName = null;
                }
            } while (string.IsNullOrWhiteSpace(lastName));

            do
            {
                Console.Write("Straße: ");
                street = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(street) || !street.Any(char.IsDigit) || !street.Any(char.IsLetter))
                {
                    ConsoleTextColorizer.WriteColoredLine("Die Straße darf nicht leer sein und muss sowohl Buchstaben als auch eine Hausnummer enthalten.", ConsoleColor.Yellow);
                    street = null;
                }
            } while (string.IsNullOrWhiteSpace(street));

            do
            {
                Console.Write("Stadt: ");
                city = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(city) || city.Any(char.IsDigit))
                {
                    ConsoleTextColorizer.WriteColoredLine("Die Stadt darf nicht leer sein und keine Zahlen enthalten.", ConsoleColor.Yellow);
                    city = null;
                }
            } while (string.IsNullOrWhiteSpace(city));

            // Postleitzahl muss genau 4 Ziffern enthalten
            do
            {
                Console.Write("Postleitzahl: ");
                postalCode = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(postalCode) || postalCode.Length != 4 || !postalCode.All(char.IsDigit))
                {
                    ConsoleTextColorizer.WriteColoredLine("Die Postleitzahl darf nicht leer sein und muss genau 4 Ziffern enthalten.", ConsoleColor.Yellow);
                    postalCode = null;
                }
            } while (string.IsNullOrWhiteSpace(postalCode));

            // Telefonnummer darf nur mit + beginnen, Ziffern, Leerzeichen und optional einem / enthalten
            Regex phonePattern = new Regex(@"^\+?\s*\d+(\s*\d+)*(\s*/\s*\d+)?\s*$");
            do
            {
                Console.Write("Telefonnummer: ");
                phoneNumber = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(phoneNumber) || !phonePattern.IsMatch(phoneNumber ?? ""))
                {
                    ConsoleTextColorizer.WriteColoredLine("Ungültige Telefonnummer. Bitte erneut eingeben.", ConsoleColor.Yellow);
                    phoneNumber = null;
                }
            } while (string.IsNullOrWhiteSpace(phoneNumber));

            // Adresse erzeugen und anzeigen
            Address address = new Address(firstName, lastName, street, city, postalCode, phoneNumber);
            address.DisplayInfo();

            // Confirm to Save
            if (AskForConfirmation("Adresse speichern?"))
            {
                try
                {
                    _addressBook.AddAddress(address);
                    ConsoleTextColorizer.WriteColoredLine($"Adresse gespeichert", ConsoleColor.Green);
                }
                catch (BaseException ex)
                {
                    ConsoleTextColorizer.WriteColoredLine($"{ex.UserMessage}", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("Adresse verworfen");
        }
        /// <summary>
        /// Prompts the user to enter a first name and last name, validates the input,
        /// searches for the corresponding address in the address book, and displays the result.
        /// </summary>
        /// <returns>
        /// The found <see cref="Address"/> object if an entry matches the given names; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// The method repeatedly asks for valid first and last names (no digits allowed).
        /// If the address is found, it is displayed; if not, a not-found message is shown.
        /// </remarks>
        public Address SearchAddressByName()
        {
            string firstName, lastName;
            do
            {
                Console.Write("Vorname: ");
                firstName = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(firstName) || firstName.Any(char.IsDigit))
                {
                    Console.WriteLine("Bitte einen gültigen Vornamen eingeben.");
                    firstName = null;
                }
            } while (string.IsNullOrWhiteSpace(firstName));

            do
            {
                Console.Write("Nachname: ");
                lastName = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(lastName) || lastName.Any(char.IsDigit))
                {
                    Console.WriteLine("Bitte einen gültigen Nachnamen eingeben.");
                    lastName = null;
                }
            } while (string.IsNullOrWhiteSpace(lastName));

            try
            {
                var result = _addressBook.FindAddress(firstName, lastName);
                Console.Clear();
                Console.WriteLine();
                result.DisplayInfo();
                return result;
            }
            catch (AddressNotFoundException)
            {
                Console.WriteLine();
                Console.WriteLine("Keinen Eintrag zu diesem Namen gefunden");
                return null;
            }
        }

        /// <summary>
        /// Deletes an address from the address book.
        /// </summary>
        /// <remarks>
        /// This method calls <see cref="SearchAddressByName"/> to find the address to be deleted.
        /// Then, the user is prompted to confirm the deletion.
        /// If confirmed, the address is removed from the address book.
        /// </remarks>
        public void DeleteAddress()
        {
            var address = SearchAddressByName();
            if (address != null)
            {
                if (AskForConfirmation("Diese Adresse wirklich löschen?"))
                {
                    try
                    {
                        _addressBook.RemoveAddress(address);
                        ConsoleTextColorizer.WriteColoredLine($"Adresse gelöscht", ConsoleColor.Green);
                    }
                    catch (BaseException ex)
                    {
                        ConsoleTextColorizer.WriteColoredLine($"{ex.UserMessage}", ConsoleColor.Red);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    Console.WriteLine("Löschen abgebrochen");
            }

        }
        /// <summary>
        /// Prompts the user with a confirmation question and returns the response as a boolean.
        /// </summary>
        /// <param name="text">The confirmation question to display to the user.</param>
        /// <returns><c>true</c> if the user confirms with 'Y'; <c>false</c> if the user responds with 'N'.</returns>
        /// <remarks>
        /// The method repeatedly asks the user until a valid input ('Y' or 'N') is entered.
        /// The input is case-insensitive and trimmed of whitespace.
        /// </remarks>
        public bool AskForConfirmation(string text)
        {
            while (true)
            {
                Console.WriteLine($"\n{text} (Y) Yes  (Y) No");
                string confirmation = Console.ReadLine()?.Trim()?.ToUpper();
                if (confirmation == "Y")
                {
                    return true;
                }
                else if (confirmation == "N")
                {
                    return false;
                }
                else
                {
                    ConsoleTextColorizer.WriteColoredLine("Invalid Input.", ConsoleColor.Yellow);
                }
            }
        }
    }
}
