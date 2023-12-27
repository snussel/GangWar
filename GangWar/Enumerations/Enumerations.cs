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
        Armor = 1,
        Weapon = 2,
        Consumable = 3,
        Other = 4
    }

    public enum EquipmentSubType
    {
        Heavy = 10,
        Medium = 11,
        Light = 12,
        Sword = 21,
        Axe = 22,
        Hammer = 23,
        Polearm = 24,
        Bow = 25,
        Crossbow = 26,
        Grenade = 31,
        Potion = 32

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
        Basic = 0,

        [EnumMember(Value = "Basic Melee")]
        [Description("This is a test")]
        BasicArmor = 1,
        
        [EnumMember(Value = "Basic Melee")]
        [Description("This is a test")]
        BasicMelee = 20,
        Sword = 21,
        Axe  = 4,
        Hammer = 5,
        Polearm = 6,
        Bow,
        Crossbow,

        [EnumMember(Value = "Basic Consumible")]
        [Description("This is a test")]
        BasicConsumible,
        Grenade,
        Potion,
        [EnumMember(Value = "Basic Other")]
        [Description("This is a test")]
        BasicOther
    }
}
