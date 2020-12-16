using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_olbul.Model
{
    public class ReadedOleg
    {

        public string NameAutor { get; set; }
        public string FantlabUrl { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }  
        public string Year { get; set; }
        public string Time { get; set; }
        public string Collection { get; set; }

        public string Description { get; set; }
        public string DescriptionFantLab { get; set; }
        public string Genre { get; set; }
        public string GenreFantLab { get; set; }
        public List<string> Image { get; set; }

        public List<string> Yandex { get; set; }
        public List<string> Mail { get; set; }
        public List<string> TorrentMp3 { get; set; }
        public List<string> TorrentAcc { get; set; }
        public string Vk { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string MyGetString()
        {
            return $"{H(NameAutor)}| {H(FantlabUrl)}| {H(Name)}| {H(Type)}| {H(Year)}| {H(Time)}| {H(Collection)}| {H(Description)}| {H(DescriptionFantLab)}|" +
                $"{H(Genre)}| {H(GenreFantLab)}| {L(Image)}| {L(Yandex)}| {L(Mail)}| {L(TorrentMp3)}| {L(TorrentAcc)}| {H(Vk)}\n";
        }

        public string MyGetHead()
        {
            return $"NameAutor| FantlabUrl| Name| Type| Year| Time| Collection| Description| DescriptionFantLab|" +
                $"Genre| GenreFantLab| Image| Yandex| Mail| TorrentMp3| TorrentAcc| Vk\n";
        }

        public string H(string s)
        {
            return $"\"{s}\"";
        }
        private string L(List<string> list)
        {
            StringBuilder result = new StringBuilder();
            result.Append("\"");
            foreach (var value in list)
                result.Append(value + "\n");
            result.Append("\"");
            return result.ToString().Trim(new char[] { '\n'});
        }
    }
}
