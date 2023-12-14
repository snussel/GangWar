using GangWar.Enumerations;
using GangWar.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GangWar
{
    internal class Output
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="thePath"></param>
        /// <param name="obj"></param>
        public static void ExportJson(string fileName, string thePath, object obj)
        {
            File.WriteAllText($"{thePath}\\{fileName}.json", JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisSquad"></param>
        /// <param name="outputPath"></param>
        public static void WriteGangToFile(SquadModel thisSquad, string outputPath)
        {
            Directory.CreateDirectory(outputPath);
            //string file = Path.Combine(AppConfig.OutputPath, $"NewGang-{DateTime.Now:MMddyyHHmm}.txt");
            string file = Path.Combine(outputPath, $"NewGang.txt");

            using var sw = new StreamWriter(file);

            WriteDashedLine(sw);
            sw.WriteLine($"│ Squad Name: {thisSquad.Name}");
            sw.WriteLine($"│ Squad Cost: {thisSquad.TotalCost} gold");
            sw.WriteLine($"│ Squad XP  : {thisSquad.TotalXP}");
            WriteFooterLine(sw);

            foreach (var character in thisSquad.ListOfCharacters)
            {
                WriteHeader(sw, "Demographics");
                sw.WriteLine($"│ Name      : {character.Name}");
                sw.WriteLine($"│ Cost      : {character.Cost,3}");
                sw.WriteLine($"│ Experience: {character.XP,3}");
                sw.WriteLine($"│ Type      : {character.Type}");
                sw.WriteLine($"│ Notes     : {character.Notes}");
                WriteFooterLine(sw);

                WriteHeader(sw, "Attributes");
                sw.WriteLine($"│ Move     : {character.Move}");
                sw.WriteLine($"│ Melee    : {character.Melee}");
                sw.WriteLine($"│ Ranged   : {character.Range}");
                sw.WriteLine($"│ Strength : {character.Strength}");
                sw.WriteLine($"│ Toughness: {character.Toughness}");
                sw.WriteLine($"│ Alertness: {character.Alertness}");
                sw.WriteLine($"│ Charisma : {character.Charisma}");
                WriteFooterLine(sw);

                if (character.ListOfSkills is not null)
                {
                    sw.WriteLine();
                    WriteHeader(sw, "Skills");
                    foreach (var skill in character.ListOfSkills.OrderBy(x => x.SkillType))
                    {
                        sw.WriteLine($"│ Name: {skill.Name}");
                        sw.WriteLine($"│ Name: {skill.SkillType}");
                        sw.WriteLine($"│ Description: {skill.Description}");
                        sw.WriteLine($"│");
                    }
                    WriteFooterLine(sw);
                }

                sw.WriteLine();
                WriteHeader(sw, "Equipment");
                foreach (var item in character.ListOfEquipment.OrderBy(x => x.EType).ThenBy(y => y.EquipmentId))
                {
                    sw.WriteLine($"│ Name       : {item.Name}");
                    sw.WriteLine($"│ Type       : {item.EType}");
                    sw.WriteLine($"│ Price      : {item.Price}");
                    sw.WriteLine($"│ Description: {item.Description}");

                    if (item.Range != 0)
                        sw.WriteLine($"│ Range      : {item.Range}");

                    sw.WriteLine($"│ {GetDiceType(item.EType),6}     : {item.NumDice}");

                    if (item.Traits is not null)
                    {
                        sw.WriteLine($"│ Trait(s)");
                        foreach (var trait in item.Traits)
                        {
                            sw.WriteLine($"│    {trait.Name} - {trait.Description}");
                        }
                    }

                    if (character.ListOfEquipment.OrderBy(x => x.EType).ThenBy(y => y.EquipmentId).Last().Equals(item))
                    {
                        //do notthing
                    }
                    else
                    {
                        WriteEquipmentLine(sw);
                    }
                }
                WriteFooterLine(sw);
            }

            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// Write summary to the screen
        /// </summary>
        /// <param name="newPC">The character</param>
        public static void WriteFinalPCToScreen(CharacterModel newPC)
        {
            //blank line
            Console.WriteLine();

            Console.WriteLine($"Name: {newPC.Name} - {newPC.Cost}");
            Console.WriteLine($" Attributes");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("| M | WS | BS | S | T | I | A | LD  |");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"| {newPC.Move} |  {newPC.Melee} |  {newPC.Range} | {newPC.Strength} | {newPC.Toughness} | {newPC.Alertness} | {newPC.Speed} |  {newPC.Charisma}  |");
            Console.WriteLine("-------------------------------------");


            Console.WriteLine($"| Personality                       |");
            Console.WriteLine($"| Agreeableness               :  {newPC.Personality.Agreeableness,2} |");
            Console.WriteLine($"| Conscientiousness           :  {newPC.Personality.Conscientiousness,2} |");
            Console.WriteLine($"| Extraversion                :  {newPC.Personality.Extraversion,2} |");            
            Console.WriteLine($"| Neuroticism                 :  {newPC.Personality.Neuroticism,2} |");
            Console.WriteLine($"| Openness                    :  {newPC.Personality.Openness,2} |");
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eType"></param>
        /// <returns></returns>
        private static string GetDiceType(EquipmentType eType) => eType switch
        {
            EquipmentType.Weapon => "Damage",
            EquipmentType.Armor => "Save",
            _ => "Unknown"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        private static void WriteDashedLine(StreamWriter sw)
        {
            sw.Write("╒");
            sw.WriteLine(new string('═', 38));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="text"></param>
        private static void WriteHeader(StreamWriter sw, string text)
        {
            sw.Write("╒");
            sw.WriteLine(new string('═', 38));


            sw.WriteLine($"│ {text}");

            sw.Write("╞");
            sw.WriteLine(new string('═', 38));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        private static void WriteFooterLine(StreamWriter sw)
        {
            sw.Write("╘");
            sw.WriteLine(new string('═', 38));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        private static void WriteEquipmentLine(StreamWriter sw)
        {
            sw.Write('├');
            sw.WriteLine(new string('─', 38));
        }
    }
}