using System.Text.Json;
using WinFormsApp1.Models;

namespace WinFormsApp1.Utils
{
    public static class Utils
    {
        public static List<CustomNote> ReadSavedNotes()
        {
            try
            {
                // Read JSON file content
                string jsonContent = File.ReadAllText(Constants.SaveFilePath);

                // Deserialize JSON to your object
                var notes = JsonSerializer.Deserialize<List<CustomNote>>(jsonContent);

                return notes?? new List<CustomNote>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<CustomNote>();
            }
        }

        public static void SavedNotes(List<CustomNote> notes)
        {
            try
            {
                // Serialize the object to JSON
                string jsonContent = JsonSerializer.Serialize(notes, new JsonSerializerOptions
                {
                    WriteIndented = true // sformats JSON for readability
                });

                // Write the JSON to the file
                File.WriteAllText(Constants.SaveFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
