using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class AdminValidator
    {
        public static bool Validate(string username, string password)
        {
            const string Path = "../../../Resources/AdminFile.txt";
            using StreamReader sr = File.OpenText(Path);

            string s = string.Empty;

            while ((s = sr.ReadLine()) != null)
            {
                string usernameFromFile = s;
                string passwordFromFile = sr.ReadLine();
                if (username != usernameFromFile || password != passwordFromFile)
                    continue;
                return true;
            }
            return false;
        }
    }
}
