using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dictionary
{
    class EntryUploader
    {
        private const string EntryPath = "../../../Resources/Dictionary.txt";
        private const string ImagePath = "/Dictionary;component/Resources/Images/";
        private const string DefaultImage = "NoImage.jpg";
        public static void Upload(string word, string category, string description, string image = DefaultImage)
        {
            using StreamWriter sw = File.AppendText(EntryPath);

            sw.WriteLine($"{word}+{category}+{description}+{ImagePath}{image}");
        }

        private static void Write(StreamWriter sw, DictionaryEntry entry) 
        {
            sw.WriteLine($"{entry.Word}+{entry.Category}+{entry.Description}+{entry.Image}");
        }
        public static void Upload(DictionaryEntry entry)
        {
            using StreamWriter sw = File.AppendText(EntryPath);
            Write(sw, entry);
        }
        public static void UploadAllButOne(DictionaryEntry entry)
        {
            List<DictionaryEntry> list = EntryDownloader.Download();
            using StreamWriter sr = new StreamWriter(EntryPath, false);

            foreach (DictionaryEntry item in list)
            {
                if (item.Word != entry.Word)
                    Write(sr, item);
            }
        }
    }
}
