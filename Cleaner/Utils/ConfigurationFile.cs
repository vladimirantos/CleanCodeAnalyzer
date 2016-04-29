using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly List<KeyValuePair<string, string>> _config;

        public ConfigurationReader(string path)
        {
            _path = path;
            _config = Parse();
        }

        /// <summary>
        /// Vrací hodnotu k zadanému klíči. Pokud klíč není nalezen metoda vrací null.
        /// </summary>
        public int? Get(string key)
        {
            foreach (var keyValuePair in _config)
            {
                if (keyValuePair.Key == key.ToUpper())
                    return int.Parse(keyValuePair.Value);
            }
            return null;
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
        private List<KeyValuePair<string, string>> Parse()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            string[] lines = ReadLines();
            foreach (var line in lines)
            {
                if (line != string.Empty)
                {
                    string[] config = line.Split('=');
                    result.Add(new KeyValuePair<string, string>(config[0], config[1]));
                }
            }
            return result;
        }
    }
}
