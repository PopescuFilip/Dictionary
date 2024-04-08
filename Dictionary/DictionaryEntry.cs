using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class DictionaryEntry
    {
        public string Word { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        override public string ToString()
        {
            return Word;
        }
	}
}
