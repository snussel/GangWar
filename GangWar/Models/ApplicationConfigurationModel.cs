using System.Text.Json.Serialization;

namespace GangWar.Models
{
    internal class ApplicationConfigurationModel
    {
        [JsonPropertyName("sourcePath")]
        public string? SourcePath { get; set; }
        
        [JsonPropertyName("outputPath")]
        public string? OutputPath { get; set; }
    }
}
