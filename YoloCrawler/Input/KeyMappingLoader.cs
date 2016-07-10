﻿namespace YoloCrawler.Input
{
    using System.IO;
    using Newtonsoft.Json;

    internal static class KeyMappingLoader
    {
        private const string KeyMappingFileName = "keyMapping.json";

        public static KeyMapping Load()
        {
            var json = File.ReadAllText(KeyMappingFileName);
            var keyMapping = JsonConvert.DeserializeObject<KeyMapping>(json);

            return keyMapping;
        }
    }
}