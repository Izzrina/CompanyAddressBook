using System;

namespace CompanyAddressBook.Models
{
    /// <summary>
    /// Represents a base abstract class for a person with a first name and last name.
    /// </summary>
    internal abstract class Person
    {
        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class
        /// with the specified first name and last name.
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Initializes a new parameterless instance of the <see cref="Person"/> class.
        /// This constructor chains to the main constructor, passing empty strings for both first and last names.
        /// 
        /// This means that when you create a Person with no parameters, it internally calls:
        /// <code>
        /// Person("", "")
        /// </code>
        /// 
        /// This is useful to avoid duplicating initialization code and ensures
        /// that <see cref="FirstName"/> and <see cref="LastName"/> are never null,
        /// but default to empty strings.
        /// </summary>
        public Person() : this("", "") { }

        /// <summary>
        /// Displays information about the person.
        /// This method can be overridden by derived classes to provide more specific details.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }

}
