using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class CategoryDownloader
    {
        private const string Path = "../../../Resources/Categories.txt";
        public static List<string> Download()
        {
            List<string> entries = new List<string>();
            using StreamReader sr = File.OpenText(Path);

            string s = string.Empty;

            while ((s = sr.ReadLine()) != null)
            {
                entries.Add(s);
            }
            return entries;
        }
    }
}
