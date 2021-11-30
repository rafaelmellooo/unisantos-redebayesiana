using System.Text.Json.Serialization;

namespace RedeBayesiana.UI.Models
{
    public class FunctionRequest
    {
        [JsonPropertyName("nomes")]
        public string[] Names { get; set; }
    }
}
