using GangWar.Enumerations;
using System.Text.Json.Serialization;

#nullable disable
namespace GangWar.Models
{
    internal class EquipmentModel
    {
        [JsonPropertyName("equipmentId")]
        public int EquipmentId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("eType")]
        public EquipmentType EType { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("numDice")]
        public int NumDice { get; set; }

        [JsonPropertyName("range")]
        public int Range { get; set; }

        [JsonPropertyName("traits")]
        public List<TraitModel> Traits { get; set; }
    }

    internal class TraitModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
