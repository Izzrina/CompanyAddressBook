using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace CompanyAddressBook.Utils
{
    internal static class JsonUtils
    {
        public static void SaveDataToJson<T>(List<T> data, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving players: {ex.Message}");
            }
        }

        public static List<T> LoadDataFromJson<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            string json = File.ReadAllText(filePath);
            //Console.WriteLine("Datei geladen");
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}
