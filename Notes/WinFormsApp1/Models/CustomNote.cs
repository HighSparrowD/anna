using System.Text.Json.Serialization;

namespace WinFormsApp1.Models
{
    [JsonSerializable(typeof(CustomNote))]
    public class CustomNote
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
        
        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;
    }
}
