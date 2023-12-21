using System.Text.Json.Serialization;

namespace GangWar.Models
{
    internal class ApplicationConfigurationModel
    {
        [JsonPropertyName("sourcePath")]
        public string? SourcePath { get; set; }
        
        [JsonPropertyName("outputPath")]
        public string? OutputPath { get; set; }

        [JsonPropertyName("debugMode")]
        public bool DebugMode { get; set; }

        [JsonPropertyName("minDieRoll")]
        public int MinDieRoll { get; set; }

        [JsonPropertyName("maxDieRoll")]
        public int MaxDieRoll { get; set; }
    }
}
