using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DB2POCO.Services
{
    public class ConfigService
    {
        private readonly string b;

        public Dictionary<string, string> List { get; }

        public ConfigService()
        {
            b = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".db2poco.txt");
            Init();
            List = Load();
            if (List.Count == 0) OpenFile(b);
        }

        private void OpenFile(string b)
        {
            throw new Exception("bad conf");
        }

        private Dictionary<string, string> Load()
            => File.ReadAllLines(b)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x) && !x.StartsWith("#") && x.Split('|').Length == 2)
                .ToDictionary(x => x.Split('|')[0], x => x.Split('|')[1]);

        private void Init()
        {
            if (!File.Exists(b))
            {
                File.WriteAllText(b, $@"#  DB2POCO.Services.ConfigService {DateTime.Now:D}
Test|Server=localhost;Database=Test;User=sa;Password=Pass~w0r8
");
            }
        }
    }
}