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

        [JsonPropertyName("equipmentAttributes")]
        public object EquipmentAttributes { get; set; }
    }

    internal class WeaponModel
    {
        [JsonPropertyName("numDiceDamage")]
        public int NumDiceDamage { get; set; }

        [JsonPropertyName("traits")]
        public List<string> Traits { get; set; }        
    }

    internal class ArmorModel
    {
        [JsonPropertyName("numDiceSaved")]
        public int DiceSaved { get; set; }
        
        [JsonPropertyName("traits")]
        public List<string> Traits { get; set; }
    }

    internal class ConsumableModel
    {
        [JsonPropertyName("numUses")]
        public int NumUses { get; set; }

        [JsonPropertyName("numDice")]
        public int NumDice { get; set; }

        [JsonPropertyName("traits")]
        public List<string> Traits { get; set; }
    }
}
