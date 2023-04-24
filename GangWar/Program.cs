using GangWar.Enumerations;
using GangWar.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

#nullable disable
namespace GangWar
{
    internal class Program
    {
        private static readonly Random _rand = new();
        private static ApplicationConfigurationModel AppConfig = new();
        static void Main(string[] args)
        {
            Console.Title = "Character Advancement Simulater";
            Console.WriteLine("Hello, All!");

            if (LoadConfig())
            {
                List<CharacterModel> listOfCharacters = new();
                var startingDetails = GetNewGangeValues();

                foreach (var person in startingDetails.Person)
                {
                    Console.WriteLine();
                    Console.Write("New Character: ");
                    ColorText(person.Key, ConsoleColor.Green);

                    var dude = CreateCharacter(person.Value.NumBattles);
                    dude.ListOfEquipment = DetermineEquipment(person.Value.StartingEquipment);
                    dude.Cost = person.Value.Cost;
                    dude.Type = person.Key;

                    WriteFinalPCToScreen(dude);
                    listOfCharacters.Add(dude);
                }

                OutputGangDetails(listOfCharacters);
            }

            Console.WriteLine("Done");
        }

        private static bool LoadConfig()
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("ApplicationConfig.json").Build();
                AppConfig = builder.GetSection("application").Get<ApplicationConfigurationModel>();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.Trim());
                return false;
            }
        }

        #region Person
        /// <summary>
        /// Method to chrate a new character and give experience to
        /// </summary>
        /// <param name="numBattles">The number of battles that the character has already participated in</param>
        /// <returns>full character</returns>
        private static CharacterModel CreateCharacter(int numBattles)
        {
            var listOfNames = GetListOfNames();
            CharacterModel character = GetNewCharacter(listOfNames);
            CharacteristicModel maxValues = GetCharacteristics("Max");
            List<ExperienceTableModel> experienceTable = GetAdvancements();
            List<AdvancementRollDetailsModel> listOfAdvancements = GetAdvancementDetails();
            List<SkillModel> listOfSkills = GetSkills();
            int maxXP = experienceTable.Last().Min;

            for (int i = 1; i <= numBattles; i++)
            {
                int randomNumber = _rand.Next(1, 9);
                Console.Write($"Roll: {i.ToString().PadLeft(2, '0')} - {character.XP,3}");

                //Get the current level of the PC
                var currentRank = experienceTable.SingleOrDefault(x => character.XP >= x.Min && character.XP <= x.Max).XP_ID;

                //This is the PCs new XP level
                int newXP = character.XP + randomNumber + 5;
                Console.WriteLine($" {newXP,3} ");

                //Get the Next level of the PC
                var nextRank = experienceTable.SingleOrDefault(x => newXP >= x.Min && newXP <= x.Max).XP_ID;

                if (currentRank < nextRank)
                {
                    for (int z = 1; z <= nextRank - currentRank; z++)
                    {
                        Console.Write($"\tRank Up {z} ");

                        //determine the result roll
                        int advanceRoll = int.Parse($"{_rand.Next(1, 9)}{_rand.Next(1, 9)}");

                        //Get the result
                        var advanceResult = listOfAdvancements.FirstOrDefault(x => advanceRoll >= x.Min && advanceRoll <= x.Max);

                        ColorText($"\t{advanceRoll} {(advanceResult.AdvancementType ? "Skill" : "Characteristic")} - {advanceResult.UpdateItem}", ConsoleColor.DarkCyan);

                        if (advanceResult.AdvancementType)
                        {
                            //New Skill
                            var newSkill = DetermineNewSkill(character.ListOfSkills.Select(x => x.SkillID).ToList(), listOfSkills.Where(x => x.SkillType.Equals(advanceResult.UpdateItem)).ToList());
                            character.ListOfSkills.Add(newSkill);
                        }
                        else
                        {
                            //Characterisitic Increase                            
                            UpdateCharacteristic(ref character, advanceResult.UpdateItem, maxValues);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\tNo advancement");
                }

                //Update XP total
                character.XP = newXP;

                //Stop looping if the charachter is already max level
                if (character.XP > maxXP) { break; }
            }

            //If no skills are determined, then set the list to null
            if (character.ListOfSkills.Count.Equals(0))
                character.ListOfSkills = null;

            return character;
        }

        /// <summary>
        /// Method to Determin a new sill to add to the character
        /// </summary>
        /// <param name="curentSkills">The currnet list of skills</param>
        /// <param name="releventSkills">The potential list of skills to choose from</param>
        /// <returns>random skill</returns>
        private static SkillModel DetermineNewSkill(List<int> curentSkills, List<SkillModel> releventSkills)
        {
            bool isUpdated = false;
            SkillModel skill = new();

            while (isUpdated.Equals(false))
            {
                int skillRoll = _rand.Next(7);

                skill = releventSkills[skillRoll];

                if (curentSkills.Contains(skill.SkillID).Equals(false))
                    isUpdated = true;
            }

            return skill;
        }

        /// <summary>
        /// Method to update a Characteristic
        /// </summary>
        /// <param name="currentCharacter">The list of values for a passed Character</param>
        /// <param name="charisticToUpdate">The Characteristic to update</param>
        /// <param name="maxValues">list of max values</param>
        private static void UpdateCharacteristic(ref CharacterModel currentCharacter, SkillTypes charisticToUpdate, CharacteristicModel maxValues)
        {
            bool isUpdated = false;

            while (isUpdated.Equals(false))
            {
                switch (charisticToUpdate)
                {
                    case SkillTypes.Movement:
                        if (currentCharacter.Move + 1 <= maxValues.Move)
                        {
                            currentCharacter.Move++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Speed:
                        if (currentCharacter.Speed + 1 <= maxValues.Speed)
                        {
                            currentCharacter.Speed++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Melee:
                        if (currentCharacter.Melee + 1 <= maxValues.Melee)
                        {
                            currentCharacter.Melee++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Ranged:
                        if (currentCharacter.Range + 1 <= maxValues.Range)
                        {
                            currentCharacter.Range++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Strength:
                        if (currentCharacter.Strength + 1 <= maxValues.Strength)
                        {
                            currentCharacter.Strength++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Toughness:
                        if (currentCharacter.Toughness + 1 <= maxValues.Toughness)
                        {
                            currentCharacter.Toughness++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Alertness:
                        if (currentCharacter.Alertness + 1 <= maxValues.Alertness)
                        {
                            currentCharacter.Alertness++;
                            isUpdated = true;
                        }
                        break;
                    case SkillTypes.Charisma:
                        if (currentCharacter.Charisma + 1 <= maxValues.Charisma)
                        {
                            currentCharacter.Charisma++;
                            isUpdated = true;
                        }
                        break;
                }

                if (isUpdated.Equals(false))
                {
                    var values = Enum.GetValues(typeof(SkillTypes));
                    charisticToUpdate = (SkillTypes)values.GetValue(_rand.Next(values.Length));
                }
            }
        }
        #endregion

        #region Equipment
        private static List<EquipmentModel> DetermineEquipment(EquipmentType[] args)
        {
            ColorText("Equipment", ConsoleColor.Green);

            List<EquipmentModel> allItems = GetEquipment();


            List<EquipmentModel> returnMe = new();

            foreach (var item in args)
            {
                if (item.Equals(EquipmentType.Weapon))
                {
                    var list = allItems.Where(x => x.EType.Equals(item)).ToList();
                }

                Console.WriteLine(item);
                returnMe.Add(new EquipmentModel { EType = item, Name = item.ToString(), EquipmentId = _rand.Next(55), });
            }


            return returnMe;
        }
        #endregion

        #region Output
        /// <summary>
        /// Write summary to the screen
        /// </summary>
        /// <param name="newPC">The character</param>
        private static void WriteFinalPCToScreen(CharacterModel newPC)
        {
            //blank line
            Console.WriteLine();

            Console.WriteLine($"Name: {newPC.Name} - {newPC.Cost}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("| M | WS | BS | S | T | I | A | LD  |");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"| {newPC.Move} |  {newPC.Melee} |  {newPC.Range} | {newPC.Strength} | {newPC.Toughness} | {newPC.Alertness} | {newPC.Speed} |  {newPC.Charisma}  |");
            Console.WriteLine("-------------------------------------");

            if (newPC.ListOfSkills is not null)
            {
                Console.WriteLine("| Skills:                           |");
                foreach (var theSkill in newPC.ListOfSkills.OrderBy(x => x.SkillType).ThenBy(y => y.SkillID))
                {
                    Console.WriteLine($"| {theSkill.SkillType,-9} {theSkill.Name,23} |");
                }
                Console.WriteLine("-------------------------------------");
            }

            Console.WriteLine("| Equipment:                        |");
            foreach (var item in newPC.ListOfEquipment.OrderBy(x => x.EType).ThenBy(y => y.EquipmentId))
            {
                Console.WriteLine($"| {item.EquipmentId,-9} {item.Name,23} |");
            }
            Console.WriteLine("-------------------------------------");
        }

        private static void OutputGangDetails(List<CharacterModel> listOfCharacters)
        {
            Directory.CreateDirectory(AppConfig.OutputPath);
            string file = Path.Combine(AppConfig.OutputPath, $"NewGang-{DateTime.Now:MMddyyHHmm}.json");
            File.WriteAllText(file, JsonSerializer.Serialize(listOfCharacters, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }));
        }
        #endregion

        #region Data Loaders
        private static GangModel GetNewGangeValues()
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\StartingGangValues.json");
            return JsonSerializer.Deserialize<GangModel>(all);
        }

        private static CharacterModel GetNewCharacter(List<string> listOfNames)
        {
            var baseValues = GetCharacteristics("Min");
            return new CharacterModel
            {
                Name = listOfNames[_rand.Next(listOfNames.Count)],
                Cost = 0,
                XP = 0,
                Speed = baseValues.Speed,
                Strength = baseValues.Strength,
                Alertness = baseValues.Alertness,
                Charisma = baseValues.Charisma,
                Melee = baseValues.Melee,
                Move = baseValues.Move,
                Range = baseValues.Range,
                Toughness = baseValues.Toughness,
                ListOfSkills = new()
            };
        }

        private static List<SkillModel> GetSkills()
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\Skills.json");
            return JsonSerializer.Deserialize<List<SkillModel>>(all);
        }

        private static CharacteristicModel GetCharacteristics(string type)
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\Characteristics.json");
            return JsonSerializer.Deserialize<List<CharacteristicModel>>(all).SingleOrDefault(x => x.Type.Equals(type));
        }

        private static List<ExperienceTableModel> GetAdvancements()
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\Advances.json");
            return JsonSerializer.Deserialize<List<ExperienceTableModel>>(all);
        }

        private static List<AdvancementRollDetailsModel> GetAdvancementDetails()
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\AdvanceRollDetails.json");
            return JsonSerializer.Deserialize<List<AdvancementRollDetailsModel>>(all);
        }

        private static List<string> GetListOfNames()
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\ListOfNames.json");
            return JsonSerializer.Deserialize<List<string>>(all);
        }

        private static List<EquipmentModel> GetEquipment()
        {
            var all = File.ReadAllText($"{AppConfig.SourcePath}\\EquipmentList.json");
            return JsonSerializer.Deserialize<List<EquipmentModel>>(all);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        private static void ExportJson(string fileName, object obj)
        {
            File.WriteAllText($"{AppConfig.SourcePath}\\{fileName}.json", JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newColor"></param>
        /// <param name="newLine"></param>
        private static void ColorText(string text, ConsoleColor newColor, bool newLine = true)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;

            if (newLine)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ForegroundColor = currentColor;
        }
        #endregion
    }
}