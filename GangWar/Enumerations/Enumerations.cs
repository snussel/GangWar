using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangWar.Enumerations
{
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
}
