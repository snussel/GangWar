using GangWar.Enumerations;
using System.Text.Json.Serialization;

#nullable disable
namespace GangWar.Models
{
    public class EquipmentModel
    {
        [JsonPropertyName("equipmentId")]
        public int EquipmentId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("equipmentMainType")]
        public EquipmentType EquipmentMainType { get; set; }

        [JsonPropertyName("equipmentSubType")]
        public EquipmentSubType EquipmentSubType { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("numDice")]
        public int NumDice { get; set; }

        [JsonPropertyName("range")]
        public int Range { get; set; }

        [JsonPropertyName("levelOfQuality")]
        public QualityLevels LevelOfQuality { get; set; }

        [JsonPropertyName("traits")]
        public List<TraitModel> Traits { get; set; } = new();
    }

    public class TraitModel
    {
        [JsonPropertyName("traitID")]
        public int TraitID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("typeOfTrait")]
        public TraitType TypeOfTrait { get; set; }
    }
}
