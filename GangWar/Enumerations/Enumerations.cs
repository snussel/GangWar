using System.ComponentModel;
using System.Runtime.Serialization;

namespace GangWar.Enumerations
{
    public enum SkillTypes
    {
        Movement = 1,
        Speed = 4,
        Melee = 2,
        Ranged = 3,
        Strength = 5,
        Toughness = 6,
        Alertness = 7,
        Charisma = 8
    }

    public enum EquipmentType 
    { 
        Armor,
        Weapon,
        Consumable,
        Other
    }

    public enum QualityLevels 
    {
        Bad = 1,
        Poor = 2,
        Average = 3,
        Good = 4,
        Excellent = 5
    }

    public enum TraitType
    {
        [EnumMember(Value = "Basic Melee")]
        [Description("This is a test")]
        BasicMelee,
        Sword,
        Axe,
        Hammer,
        Polearm,
        [EnumMember(Value = "Basic Ranged")]
        [Description("This is a test")]
        BasicRanged,
        Bow,
        Crossbow,
        [EnumMember(Value = "Basic Consumible")]
        [Description("This is a test")]
        BasicConsumible,
        Grenade,
        [EnumMember(Value = "Basic Other")]
        [Description("This is a test")]
        BasicOther
    }
}
