﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils.Extensions;

namespace Cleaner.Utils
{
    /// <summary>
    /// Třída se stará o ukládání a načítání konstant ze souboru.
    /// Konstanty jsou uloženy ve tvaru klíč=hodnota
    /// </summary>
    static class ConfigurationFile
    {
        public static ConfigurationWriter Writer() => new ConfigurationWriter();
        public static ConfigurationReader Reader(string path) => new ConfigurationReader(path);
    }

    /// <summary>
    /// Třída pro ukládání konfiguračních dat.
    /// </summary>
    internal sealed class ConfigurationWriter
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        /// <summary>
        /// Připraví pro vložení klíč=hodnota.
        /// </summary>
        public void Add(string key, object value) => _stringBuilder.AppendLine($"{key.ToUpper()}={value}");

        /// <summary>
        /// Připraví pro vložení sérii klíčů a hodnot.
        /// </summary>
        public void Add(Dictionary<string, object> content)
        {
            foreach (KeyValuePair<string, object> keyValuePair in content)
            {
                Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        /// <summary>
        /// Uloží konfiguraci.
        /// </summary>
        public void Save(string path) => FileUtils.WriteFile(path, _stringBuilder.ToString());
    }

    /// <summary>
    /// Třída pro čtení konfiguračních dat. Získává hodnotu podle zadaného klíče.
    /// </summary>
    internal sealed class ConfigurationReader
    {
        private readonly string _path;
        public Dictionary<string, float> ConfigData { get; }

        public ConfigurationReader(string path)
        {
            _path = path;
            ConfigData = Parse();
        }

        /// <summary>
        /// Vrací hodnotu k zadanému klíči. Pokud klíč není nalezen metoda vrací null.
        /// </summary>
        public float? Get(string key)
        {
            if (ConfigData.ContainsKey(key))
                return ConfigData[key];
            throw new ArgumentException($"Key {key} not contains in configuration file.");
        }

        private string[] ReadLines()
        {
            string content = FileUtils.ReadFile(_path);
            return content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Vytvoří seznam dvojic typu klíč-hodnota.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, float> Parse()
        {
            Dictionary<string, float> result = new Dictionary<string, float>();
            string[] lines = ReadLines();
            if(lines.IsEmpty())
                throw new InvalidOperationException("There are no calibration data.");
            foreach (var line in lines)
            {
                if (line != string.Empty)
                {
                    string[] config = line.Split('=');
                    result.Add(config[0], float.Parse(config[1]));
                }
            }
            return result;
        }
    }
}
