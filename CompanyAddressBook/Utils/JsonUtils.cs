using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace CompanyAddressBook.Utils
{
    internal static class JsonUtils
    {
        /// <summary>
        /// Saves a list of data objects to a JSON file at the specified file path.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the list to serialize.</typeparam>
        /// <param name="data">The list of objects to be saved as JSON.</param>
        /// <param name="filePath">The path to the file where the JSON data will be written.</param>
        /// <returns>
        /// <c>true</c> if the data was successfully saved; otherwise, <c>false</c> if an error occurred.
        /// </returns>
        /// <remarks>
        /// If the file cannot be written (e.g., due to permission issues or invalid path),
        /// the method logs the exception message to the console and returns <c>false</c>.
        /// </remarks>
        public static bool SaveDataToJson<T>(List<T> data, string filePath)
        {
            try
            {
                Console.WriteLine($"Speichere Liste nach {Path.GetFullPath(filePath)}");
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Loads a list of data objects from a JSON file at the specified file path.
        /// </summary>
        /// <typeparam name="T">The type of the objects to deserialize from the JSON file.</typeparam>
        /// <param name="filePath">The path to the JSON file to read.</param>
        /// <returns>
        /// A list of deserialized objects of type <typeparamref name="T"/>.
        /// Returns an empty list if the file does not exist, is empty, or cannot be read.
        /// </returns>
        /// <remarks>
        /// If the file is not found or an exception occurs during reading or deserialization,
        /// the method logs the error to the console and returns an empty list instead of throwing an exception.
        /// </remarks>
        public static List<T> LoadDataFromJson<T>(string filePath)
        {
            Console.WriteLine($"Lade Adressen von {Path.GetFullPath(filePath)}");
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            try
            {
                string json = File.ReadAllText(filePath);
                //Console.WriteLine("Datei geladen");
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>(); //Null-Coalescing Operator -> if File is empty return emty list instead of null
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Datei '{filePath}': {ex.Message}");
                return new List<T>();
            }

        }
    }
}
