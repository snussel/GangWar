using GangWar.Enumerations;
using System.Text.Json.Serialization;

#nullable disable
namespace GangWar.Models
{
    internal class SquadModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("totalXP")]
        public int TotalXP { get; set; }

        [JsonPropertyName("totalCost")]
        public int TotalCost { get; set; }

        [JsonPropertyName("listOfCharacters")]
        public List<CharacterModel> ListOfCharacters { get; set; }
    }

    internal class GangModel
    {
        [JsonPropertyName("Person")]
        public Dictionary<string, PersonModel> Person { get; set; }
    }

    internal class PersonModel
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("numBattles")]
        public int NumBattles { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("startingEquipment")]
        public EquipmentType[] StartingEquipment { get; set; }

        [JsonPropertyName("maxQuality")]
        public QualityLevels MaxQuality { get; set; }

    }

    internal class CharacterModel : CharacteristicModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        [JsonPropertyName("Cost")]
        public int Cost { get; set; }

        [JsonPropertyName("xP")]
        public int XP { get; set; }

        [JsonPropertyName("numBattles")]
        public int NumBattles { get; set; }

        [JsonPropertyName("listOfSkills")]
        public List<SkillModel> ListOfSkills { get; set; }

        [JsonPropertyName("listOfEquipment")]
        public List<EquipmentModel> ListOfEquipment { get; set; }
    }

    internal class CharacteristicModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("move")]
        public int Move { get; set; }

        [JsonPropertyName("melee")]
        public int Melee { get; set; }

        [JsonPropertyName("range")]
        public int Range { get; set; }

        [JsonPropertyName("strength")]
        public int Strength { get; set; }

        [JsonPropertyName("toughness")]
        public int Toughness { get; set; }

        [JsonPropertyName("alertness")]
        public int Alertness { get; set; }

        [JsonPropertyName("charisma")]
        public int Charisma { get; set; }

        [JsonPropertyName("speed")]
        public int Speed { get; set; }

        [JsonPropertyName("personality")]
        public PersonalityModel Personality { get; set; }
    }

    internal class PersonalityModel
    {
        [JsonPropertyName("Agreeableness")]
        public int Agreeableness { get; set; }

        [JsonPropertyName("Conscientiousness")]
        public int Conscientiousness { get; set; }

        [JsonPropertyName("Extraversion")]
        public int Extraversion { get; set; }

        [JsonPropertyName("Neuroticism")]
        public int Neuroticism { get; set; }

        [JsonPropertyName("Openness")]
        public int Openness { get; set; }
    }

    internal class ExperienceTableModel
    {
        [JsonPropertyName("xPID")]
        public int XP_ID { get; set; }

        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }

    internal class AdvancementRollDetailsModel
    {
        [JsonPropertyName("rollID")]
        public int RollID { get; set; }

        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// If this is a skill or characterisitc advancement
        /// True = Skill
        /// False = Charastic
        /// </summary>
        [JsonPropertyName("aType")]
        public bool AdvancementType { get; set; }

        [JsonPropertyName("updateItem")]
        public SkillTypes UpdateItem { get; set; }
    }

    internal class SkillModel
    {
        [JsonPropertyName("skillId")]
        public int SkillID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("skillType")]
        public SkillTypes SkillType { get; set; }

        [JsonPropertyName("roll")]
        public int Roll { get; set; }
    }
}