using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using vk_olbul.Model;

namespace vk_olbul.BL
{
    public static class Common
    {
        public static List<Pages> GetAllPagesFromFile()
        {
            List<Pages> listPages = new List<Pages>();
            string sourceText = InputOutputService.ReadTextFromFile("AllBookFromVK.txt");
            var ListSourcePAges = sourceText.Split(new string[] { "<-------------------------------------------------------------------->" }, StringSplitOptions.None);
            foreach (var item in ListSourcePAges)
            {
                var regText = GetTextFromRegex(new Regex("(?<={\"response\":)({.*?})"), item);
                listPages.Add(JsonConvert.DeserializeObject<Pages>(regText));
            }
            return listPages;
        }

        private static string GetTextFromRegex(Regex regex, string sourceText)
        {
            var matchList = regex.Matches(sourceText);
            StringBuilder result = new StringBuilder();
            foreach (Match match in matchList)
                result.Append(match.Value);
            return result.ToString();
        }
    }
}
