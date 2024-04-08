using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class CategoryUploader
    {
        private const string Path = "../../../Resources/Categories.txt";
        public static void Upload(string category)
        {
            using StreamWriter sw = File.AppendText(Path);
            sw.WriteLine(category);
        }
    }
}
