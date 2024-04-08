using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class EntryDownloader
    {
        private const string EntryPath = "../../../Resources/Dictionary.txt";
        private static DictionaryEntry GetDictionaryEntryFromString(string s)
        {
            string[] properties = s.Split('+');
            string word = properties[0];
            string category = properties[1];
            string description = properties[2];
            string image = properties[3];
            DictionaryEntry entry = new DictionaryEntry() { Word = word, Category = category, Description = description, Image = image};
            return entry;
        }
        public static List<DictionaryEntry> Download()
        {
            List<DictionaryEntry> entries = new List<DictionaryEntry>();
            using StreamReader sr = File.OpenText(EntryPath);

            string s = string.Empty;

            while ((s = sr.ReadLine()) != null)
            {
                entries.Add(GetDictionaryEntryFromString(s));
            }
            return entries;
        }
        
    }
}
