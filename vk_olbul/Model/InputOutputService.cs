using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_olbul.Model
{
    public static class InputOutputService 
    {
        public static void SaveTextInFile(string fileName, string text)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName);

            using (StreamWriter sr = new StreamWriter(path, false, Encoding.UTF8))
            {
                sr.Write(text);
            }
        }

        public static string ReadTextFromFile(string fileName)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName);

            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        public static bool IsExists(string fileName)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName);
            return File.Exists(path);
        }
    }
}
