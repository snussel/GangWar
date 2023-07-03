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
                //Armor
                new EquipmentModel
                {
                    Name = "Light Armor",
                    Price = 2,
                    Description = "Made of cloth and bits of leather",
                    EType = EquipmentType.Armor,
                    NumDice = 1
                },
                new EquipmentModel
                {
                    Name = "Medium Armor",
                    Price = 2,
                    Description = "Standard armor, that might be made of tanned hides and a bit of metal mixed in",
                    EType = EquipmentType.Armor,
                    NumDice = 2
                },
                new EquipmentModel
                {
                    Name = "Heavy Armor",
                    Price = 2,
                    Description = "Most protective armor, made mostly of metal",
                    EType = EquipmentType.Armor,
                    NumDice = 3
                },

                //Melee Weapons
                new EquipmentModel
                {
                    Name = "Knife",
                    Price = 0,
                    Description = "Basic melee weapon",
                    EType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Sword",
                    Price = 2,
                    Description = "Bread and butter melee weapon",
                    EType = EquipmentType.Weapon,
                    NumDice = 3
                },
                new EquipmentModel
                {
                    Name = "Axe",
                    Price = 2,
                    Description = "",
                    EType = EquipmentType.Weapon,
                    NumDice = 1
                },

                //Ranged Weapons
                new EquipmentModel
                {
                    Name = "Crossbow",
                    Price = 2,
                    Description = "",
                    EType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Short Bow",
                    Price = 2,
                    Description = "",
                    EType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Long Bow",
                    Price = 3,
                    Description = "",
                    EType = EquipmentType.Weapon,
                    NumDice = 1,
                    Range = 8
                },

                //Consumible
                new EquipmentModel
                {
                    Name = "Smoke",
                    Price = 1,
                    Description = "Grenade",
                    EType = EquipmentType.Consumable,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Fire",
                    Price = 1,
                    Description = "Grenade",
                    EType = EquipmentType.Consumable,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Schrapnel",
                    Price = 1,
                    Description = "Grenade",
                    EType = EquipmentType.Consumable,
                    NumDice = 1,
                    Range = 4
                },
                new EquipmentModel
                {
                    Name = "Medical Pack",
                    Price = 1,
                    Description = "Try to heal one's self",
                    EType = EquipmentType.Consumable,
                    NumDice = 1
                },

                //Other
                new EquipmentModel
                {
                    Name = "Lock Picks",
                    Price = 10,
                    Description = "",
                    EType = EquipmentType.Other,
                    NumDice = 1
                },
                new EquipmentModel
                {
                    Name = "Mule",
                    Price = 100,
                    Description = "",
                    EType = EquipmentType.Other,
                    NumDice = 3
                }
            };

            //
            for (int i = 0; i < list.Count; i++)
                list[i].EquipmentId = i + 1;

            Output.ExportJson("EquipmentList", pathToFiles, list);

            //
            List<TraitModel> list2 = new() 
            { 
                new TraitModel { TypeOfTrait = TraitType.BasicMelee, Name = "Basic", Description = "One free level or repair" },
                new TraitModel { Name = "Usefull", Description = "May draw light items as a free action" },
                new TraitModel { Name = "Cumbersome", Description = "Trait maximum for all movement tests is 4\"" },
                new TraitModel { Name = "Robust", Description = "Reroll one failed save, must take the second result" },
                new TraitModel { Name = "Light", Description = "Can be thrown" },
                new TraitModel { Name = "Versitile", Description = "" },
                new TraitModel { Name = "Slow", Description = "" },
                new TraitModel { Name = "Capacity(4)", Description = "" },
                new TraitModel { Name = "Gas", Description = "" },
                new TraitModel { Name = "Liquid", Description = "" },
                new TraitModel { Name = "Explosive", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
                new TraitModel { Name = "", Description = "" },
            };

            //
            for (int i = 0; i < list2.Count; i++)
                list2[i].TraitID = i + 1;

            Output.ExportJson("TraitList", pathToFiles, list2);
        }
    }
}
