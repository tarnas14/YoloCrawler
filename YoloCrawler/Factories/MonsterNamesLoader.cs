namespace YoloCrawler.Factories
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    internal static class MonsterNamesLoader
    {
        private const string MonsterNamesFileName = "monsterNames.json";

        public static List<string> Load()
        {
            
            var json = File.ReadAllText(MonsterNamesFileName);
            var monsters = JsonConvert.DeserializeObject<List<string>>(json);

            return monsters;
        }
    }
}