using System;

namespace CompanyAddressBook.Exceptions
{
    /// <summary>
    /// Represents the base class for custom exceptions with support for error codes and user-friendly messages.
    /// It inherits from the built-in System.Exception class.
    /// </summary>
    public class BaseException : Exception
    {
        /// <summary>
        /// Gets the custom error code that identifies the type of error (e.g., "DUPLICATE_PHONE", "NOT_FOUND").
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Gets a user-friendly message that can be displayed to the end user.
        /// By default, this returns the technical error message from the base <see cref="Exception.Message"/>.
        /// Derived classes can override this property to provide a more specific message.
        /// </summary>
        public virtual string UserMessage => Message;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class with a specified error message and optional error code.
        /// </summary>
        /// <param name="message">The technical error message that describes the error.</param>
        /// <param name="errorCode">An optional error code that categorizes the error. Defaults to "UNKNOWN_ERROR".</param>
        public BaseException(string message, string errorCode = "UNKNOWN_ERROR")
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
