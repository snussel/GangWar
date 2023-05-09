using GangWar.Enumerations;
using GangWar.Models;

namespace GangWar
{
    internal class SeedConfigValues
    {
        public static void SeedJsonValues(string pathToFiles)
        {
            List<EquipmentModel> list = new()
            {
                new EquipmentModel
                {
                    Name = "Light Armor",
                    Price = 2,
                    Description = "Made of cloth and bits of leather",
                    EType = EquipmentType.Armor,
                    NumDice = 1,
                    Traits = new List<TraitModel>
                    {
                        new TraitModel { Name = "Basic", Description = "One free level or repair" }
                    }
                },
                new EquipmentModel
                {
                    Name = "Medium Armor",
                    Price = 2,
                    Description = "Standard armor, that might be made of tanned hides and a bit of metal mixed in",
                    EType = EquipmentType.Armor,
                    NumDice = 2,
                    Traits = new List<TraitModel>
                    {
                        new TraitModel { Name = "Usefull", Description = "May draw light items as a free action" },
                    }
                },
                new EquipmentModel
                {
                    Name = "Heavy Armor",
                    Price = 2,
                    Description = "Most protective armor, made mostly of metal",
                    EType = EquipmentType.Armor,
                    NumDice = 3,
                    Traits = new List<TraitModel>
                    {
                        new TraitModel { Name = "Cumbersome", Description = "Trait maximum for all movement tests is 4" },
                        new TraitModel { Name = "Robust", Description = "Reroll one failed save, must take the second result" }
                    }
                },

                new EquipmentModel
                {
                    Name = "Knife",
                    Price = 0,
                    Description = "Basic melee weapon",
                    EType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4,
                    Traits = new List<TraitModel>
                    {
                        new TraitModel { Name = "Light", Description = "Can be thrown" },
                        new TraitModel { Name = "Basic", Description = "One free level or repair" }
                    }
                },
                new EquipmentModel
                {
                    Name = "Sword",
                    Price = 2,
                    Description = "Bread and butter melee weapon",
                    EType = EquipmentType.Weapon,
                    NumDice = 3,
                    Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } }
                },
                new EquipmentModel { Name = "Axe", Price = 2, Description = "", EType = EquipmentType.Weapon , NumDice = 1, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },

                new EquipmentModel { Name = "Crossbow", Price = 2, Description = "", EType = EquipmentType.Weapon, NumDice = 1,Range = 4,Traits = new List < TraitModel > { new TraitModel { Name = "Slow", Description = "" }, new TraitModel { Name = "Capacity(4)", Description = "" }, new TraitModel { Name = "Basic", Description = "" } }},
                new EquipmentModel { Name = "Short Bow", Price = 2, Description = "", EType = EquipmentType.Weapon, NumDice = 1, Range = 4, Traits = new List < TraitModel > { new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel { Name = "Basic", Description = "" } }},
                new EquipmentModel { Name = "Long Bow", Price = 3, Description = "", EType = EquipmentType.Weapon, NumDice = 1, Range = 8, Traits = new List <TraitModel> { new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel { Name = "Basic", Description = "" } }},



                new EquipmentModel { Name = "Smoke", Price = 1, Description = "Grenade", EType = EquipmentType.Consumable , NumDice = 1, Range = 4, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Gas", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },
                new EquipmentModel { Name = "Fire", Price = 1, Description = "Grenade", EType = EquipmentType.Consumable , NumDice = 1, Range = 4, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Liquid", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },
                new EquipmentModel { Name = "Schrapnel", Price = 1, Description = "Grenade", EType = EquipmentType.Consumable , NumDice = 1, Range = 4, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Explosive", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },
                new EquipmentModel { Name = "Medical Pack", Price = 1, Description = "Try to heal one's self", EType = EquipmentType.Consumable , NumDice = 1, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },

                //new EquipmentModel { Name = "Wand", Price = 1000, Description = "", EType = EquipmentType.Other , NumDice = 1, Range = 4, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },
                new EquipmentModel { Name = "Lock Picks", Price = 10, Description = "", EType = EquipmentType.Other , NumDice = 1, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } },
                new EquipmentModel { Name = "Muel", Price = 100, Description = "", EType = EquipmentType.Other , NumDice = 3, Traits = new List<TraitModel>{ new TraitModel { Name = "Light", Description = "" }, new TraitModel { Name = "Versitile", Description = "" }, new TraitModel {  Name = "Basic", Description = "" } } }

            };

            //
            for (int i = 0; i < list.Count; i++)
                list[i].EquipmentId = i + 1;

            Output.ExportJson("EquipmentList", pathToFiles, list);            
        }
    }
}
