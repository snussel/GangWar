using GangWar.Enumerations;
using GangWar.Models;

namespace GangWar
{
    internal class SeedConfigValues
    {
        public static void SeedJsonValues(char[] seedType, string pathToFiles)
        {
            foreach (char sType in seedType) 
            {
                switch(sType)
                {
                    case 'T':
                        SeedTraits(pathToFiles);
                        break;
                    case 'E':
                        SeedEquipment(pathToFiles); 
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        private static void SeedEquipment(string pathToFiles)
        {
            List<EquipmentModel> list = new()
            {
                //Armor
                new EquipmentModel
                {
                    Name = "Light Armor",
                    Price = 2,
                    Description = "Made of cloth and bits of leather",
                    EquipmentMainType = EquipmentType.Armor, 
                    EquipmentSubType = EquipmentSubType.Light,
                    NumDice = 1
                },
                new EquipmentModel
                {
                    Name = "Medium Armor",
                    Price = 2,
                    Description = "Standard armor, that might be made of tanned hides and a bit of metal mixed in",
                    EquipmentMainType = EquipmentType.Armor,
                    EquipmentSubType = EquipmentSubType.Medium,
                    NumDice = 2
                },
                new EquipmentModel
                {
                    Name = "Heavy Armor",
                    Price = 2,
                    Description = "Most protective armor, made mostly of metal",
                    EquipmentMainType = EquipmentType.Armor,
                    EquipmentSubType = EquipmentSubType.Heavy,
                    NumDice = 3
                },

                //Melee Weapons
                new EquipmentModel
                {
                    Name = "Knife",
                    Price = 0,
                    Description = "Basic melee weapon",
                    EquipmentMainType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Sword",
                    Price = 2,
                    Description = "Bread and butter melee weapon",
                    EquipmentMainType = EquipmentType.Weapon,
                    NumDice = 3
                },
                new EquipmentModel
                {
                    Name = "Axe",
                    Price = 2,
                    Description = "",
                    EquipmentMainType = EquipmentType.Weapon,
                    NumDice = 1
                },

                //Ranged Weapons
                new EquipmentModel
                {
                    Name = "Crossbow",
                    Price = 2,
                    Description = "",
                    EquipmentMainType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Short Bow",
                    Price = 2,
                    Description = "",
                    EquipmentMainType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Long Bow",
                    Price = 3,
                    Description = "",
                    EquipmentMainType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 8
                },

                //Consumible
                new EquipmentModel
                {
                    Name = "Smoke",
                    Price = 1,
                    Description = "Grenade",
                    EquipmentMainType = EquipmentType.Consumable,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Fire",
                    Price = 1,
                    Description = "Grenade",
                    EquipmentMainType = EquipmentType.Consumable,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Schrapnel",
                    Price = 1,
                    Description = "Grenade",
                    EquipmentMainType = EquipmentType.Consumable,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Medical Pack",
                    Price = 1,
                    Description = "Try to heal one's self",
                    EquipmentMainType = EquipmentType.Consumable,
                    NumDice = 1
                },

                //Other
                new EquipmentModel
                {
                    Name = "Lock Picks",
                    Price = 10,
                    Description = "",
                    EquipmentMainType = EquipmentType.Other,
                    NumDice = 1
                },
                new EquipmentModel
                {
                    Name = "Mule",
                    Price = 100,
                    Description = "",
                    EquipmentMainType = EquipmentType.Other,
                    NumDice = 3
                }
            };

            //
            for (int i = 0; i < list.Count; i++)
                list[i].EquipmentId = i + 1;

            Output.ExportJson("EquipmentList", pathToFiles, list);
        }

        private static void SeedTraits(string pathToFiles)
        {
            //
            List<TraitModel> list2 = new()
            {
                new TraitModel { TypeOfTrait = TraitType.BasicArmor, Name = "Basic", Description = "One free level or repair" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor, Name = "Usefull", Description = "May draw light items as a free action" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor, Name = "Cumbersome", Description = "Trait maximum for all movement tests is 4\"" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor, Name = "Robust", Description = "Reroll one failed save, must take the second result" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor,  Name = "Light", Description = "Can be thrown" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor,  Name = "Versitile", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor,  Name = "Slow", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicArmor,  Name = "Capacity(4)", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.BasicMelee, Name = "Basic", Description = "One free level or repair" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee, Name = "Usefull", Description = "May draw light items as a free action" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee, Name = "Cumbersome", Description = "Trait maximum for all movement tests is 4\"" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee, Name = "Robust", Description = "Reroll one failed save, must take the second result" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee,  Name = "Light", Description = "Can be thrown" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee,  Name = "Versitile", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee,  Name = "Slow", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicMelee,  Name = "Capacity(4)", Description = "" },
                
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Gas", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Liquid", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Explosive", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Axe, Name = "Placeholder ", Description = "" },
                
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Sword, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Hammer, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Polearm, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "Placeholder " },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "Placeholder " },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "Placeholder " },
                new TraitModel { TypeOfTrait = TraitType.Bow, Name = "Placeholder ", Description = "Placeholder " },

                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Crossbow, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicConsumible, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Grenade, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.Potion, Name = "Placeholder ", Description = "" },

                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 1", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 2", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 3", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 4", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 5", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 6", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 7", Description = "" },
                new TraitModel { TypeOfTrait = TraitType.BasicOther, Name = "Placeholder 8", Description = "" }
            };

            //
            for (int i = 0; i < list2.Count; i++)
                list2[i].TraitID = i + 1;

            Output.ExportJson("TraitList", pathToFiles, list2);
        }
    }
}
