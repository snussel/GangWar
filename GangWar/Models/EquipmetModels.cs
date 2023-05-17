using GangWar.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

#nullable disable
namespace GangWar.Models
{
    public class EquipmentContext : DbContext
    { 
        public DbSet<EquipmentModel> Equipment { get; set; }
        public DbSet<TraitModel> Traits { get; set; }
    }


    public class EquipmentModel
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

        [JsonPropertyName("levelOfQuality")]
        public QualityLevels LevelOfQuality { get; set; }

        [JsonPropertyName("traits")]
        public List<TraitModel> Traits { get; } = new();
    }

    public class TraitModel
    {
        [JsonPropertyName("traitID")]
        public int TraitID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public int EquipmentId { get; set; }
    }
}
