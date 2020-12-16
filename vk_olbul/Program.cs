using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Newtonsoft.Json;
using vk_olbul.Model;
using vk_olbul.BL;

namespace vk_olbul
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] badpages = {
                "https://m.vk.com/page-39897717_47391489?api_view=dda899ff1267ef7de94f126fbdd799",
                "https://m.vk.com/page-39897717_47391490?api_view=b8ebd8ad668b4b9bb94f165ba8ff54",
                "https://m.vk.com/page-39897717_47391495?api_view=be93a4973c99989bd94f11dc6b5c4a",
                "https://m.vk.com/page-39897717_47391498?api_view=a4c1ffd07bf6e4ea794f14f9df2e57",
                "https://m.vk.com/page-39897717_47397938?api_view=4110c3cb95631414294f19ea1e9ab9",
                "https://m.vk.com/page-39897717_47397950?api_view=18f6245698f05771b94f178467474c",
                "https://m.vk.com/page-39897717_47401664?api_view=a44080d1d989a88a794f1cee2f3a70",
                "https://m.vk.com/page-39897717_47580817?api_view=718eff32763d3117294f1009d10795",
                "https://m.vk.com/page-39897717_49912512?api_view=b7981e6d89dd49db494f1167c4feb4",
                "https://m.vk.com/page-39897717_52262224?api_view=069837b4c3c2d230594f11655960e4",
                "https://m.vk.com/page-39897717_52262225?api_view=5b0e47d88455d5a5894f18025fa49d",
                "https://m.vk.com/page-39897717_52262226?api_view=7f26c30ba03ffd77c94f1a8a129f80",
                "https://m.vk.com/page-39897717_52262227?api_view=8a9b851dcc4db0b8994f115e73fce9",
                "https://m.vk.com/page-39897717_52262228?api_view=20069b1c7900ffc2394f188f93e2ad",
                "https://m.vk.com/page-39897717_54717927?api_view=2233c2804b6cc102194f1bda0a298a"};
            string yani = "OYt0jj4luK4";
            string mail = "2ee86/2LBf972pPxM";
            string torrentMp3 = "XKGMLARjrQk";
            string torrentAcc = "ZPiE5IfoMrw";

            List<Pages> allPages = Common.GetAllPagesFromFile();
            List<ReadedOleg> readedOlegTablesAll = new List<ReadedOleg>();
            List<ReadedOleg> readedOlegTables_Good = new List<ReadedOleg>();
            List<ReadedOleg> readedOlegTables_Bad = new List<ReadedOleg>();
            System.Data.DataSet result;

            allPages = allPages.Where(x => !badpages.Any(f => f == x.view_url)).ToList();

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "AllBookFromGoogleDrive.csv");
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    do { while (reader.Read()) { } } while (reader.NextResult());
                    result = reader.AsDataSet();
                }
            }
            for (int i = 1; i < result.Tables[0].Rows.Count; i++)
            {
                ReadedOleg readedOleg = new ReadedOleg();

                readedOleg.NameAutor = (string)result.Tables[0].Rows[i].ItemArray[0];
                readedOleg.Name = (string)result.Tables[0].Rows[i].ItemArray[1];
                readedOleg.Type = (string)result.Tables[0].Rows[i].ItemArray[2];
                readedOleg.Year = (string)result.Tables[0].Rows[i].ItemArray[3];
                readedOleg.Time = (string)result.Tables[0].Rows[i].ItemArray[4];
                readedOleg.Collection = (string)result.Tables[0].Rows[i].ItemArray[5];

                readedOleg.Vk = $"{(string)result.Tables[0].Rows[i].ItemArray[6]}";

                readedOleg.Yandex = new List<string>();
                readedOleg.Mail = new List<string>();
                readedOleg.TorrentAcc = new List<string>();
                readedOleg.TorrentMp3 = new List<string>();
                readedOleg.Image = new List<string>();

                readedOleg.GenreFantLab = "";
                readedOleg.DescriptionFantLab = "";
                readedOlegTablesAll.Add(readedOleg);
            }
            IWebDriver browser = new FirefoxDriver();
            browser.Manage().Window.Maximize();
            //int @break = 0;
            foreach (var item in readedOlegTablesAll)
            {
                List<Pages> temp = new List<Pages>();
                if (!string.IsNullOrWhiteSpace(item.Vk))
                {
                    temp = allPages.Where(x => Regex.IsMatch(x.view_url, item.Vk, RegexOptions.IgnoreCase)).ToList();
                }
                if (temp.Count > 1) throw new Exception();
                else if (temp.Count == 0)
                    readedOlegTables_Bad.Add(item);
                else
                {
                    Pages pages = temp.First();
                    item.Vk = Regex.Replace(Regex.Replace(pages.view_url, @"m\.", ""), @"\?api_view=.*", ""); //Vk


                    List<string> TagsA = Regex.Matches(pages.html, @"(\<a)(.*?)(\<img)(.*?)(\</a\>)").Cast<Match>().Select(m => m.Value).ToList();
                    TagsA = TagsA.Where(x => !Regex.IsMatch(x, "OJEe4lvaPyw|X1TwHh7IhQ0", RegexOptions.IgnoreCase)).ToList();


                    List<string> yaniA = TagsA.Where(x => Regex.IsMatch(x, yani, RegexOptions.IgnoreCase)).ToList();
                    List<string> mailA = TagsA.Where(x => Regex.IsMatch(x, mail, RegexOptions.IgnoreCase)).ToList();
                    List<string> torrentMp3A = TagsA.Where(x => Regex.IsMatch(x, torrentMp3, RegexOptions.IgnoreCase)).ToList();
                    List<string> torrentAccA = TagsA.Where(x => Regex.IsMatch(x, torrentAcc, RegexOptions.IgnoreCase)).ToList();

                    foreach (var yaniAitem in yaniA)
                    {
                        if (!Regex.IsMatch(yaniAitem, @"(?<=goAway\(')(.*?)(?='\))"))
                            throw new Exception();
                        item.Yandex.Add(Regex.Match(yaniAitem, @"(?<=goAway\(')(.*?)(?='\))").Value);
                    } // yadi

                    foreach (var mailAitem in mailA)
                    {
                        if (!Regex.IsMatch(mailAitem, @"(?<=goAway\(')(.*?)(?='\))"))
                            throw new Exception();
                        item.Mail.Add(Regex.Match(mailAitem, @"(?<=goAway\(')(.*?)(?='\))").Value);
                    } // mail
                    
                    foreach (var torrentMp3Aitem in torrentMp3A)
                    {
                        if (!Regex.IsMatch(torrentMp3Aitem, @"(?<=goAway\(')(.*?)(?='\))"))
                        {

                        }
                        else
                        {
                            item.TorrentMp3.Add(Regex.Match(torrentMp3Aitem, @"(?<=goAway\(')(.*?)(?='\))").Value);
                        }
                    } // torrent mp3

                    foreach (var torrentAccAAitem in torrentAccA) 
                    {
                        if (!Regex.IsMatch(torrentAccAAitem, @"(?<=goAway\(')(.*?)(?='\))")) 
                            throw new Exception();
                        item.TorrentAcc.Add(Regex.Match(torrentAccAAitem, @"(?<=goAway\(')(.*?)(?='\))").Value);
                    } // torrent acc

                    List<string> allImage= Regex.Matches(pages.html, @"(\<img)(.*?)(\>)").Cast<Match>().Select(m => m.Value).ToList();
                    List<string> imegeA = allImage.Where(x=> !Regex.IsMatch(x, "OJEe4lvaPyw|X1TwHh7IhQ0|OYt0jj4luK4|2LBf972pPxM|XKGMLARjrQk|ZPiE5IfoMrw", RegexOptions.IgnoreCase)).ToList();
                    foreach (var image in imegeA) // image
                    {
                        item.Image.Add(Regex.Match(image, "(?<=src=\\\")(.*?)(?=\\\")").Value);
                    } // image

                    item.Genre = Regex.Match(pages.html, @"(?i)(?<=жанры??\W*:)(.*?)(?=<br)").Value;
                    item.Genre = Regex.Replace(item.Genre, "<.*?>", "").Trim();
                    if (!string.IsNullOrWhiteSpace(item.Collection))
                        item.Genre = item.Genre.ToUpper();

                    item.Description = Regex.Match(pages.html, @"(?i)(?<=описание\W*:)(.|\n|\r)+?(?=\<a|\<b\>)").Value;
                    item.Description = Regex.Replace(item.Description, "<.*?>", "").Trim();
                    item.Description = Regex.Replace(item.Description, "\"", "\"\"");
                    if (!string.IsNullOrWhiteSpace(item.Collection))
                        item.Description = item.Description.ToUpper();

                    browser.Navigate().GoToUrl("https://fantlab.ru/search-advanced");

                    browser.FindElement(By.Id("ef_name")).SendKeys(item.Name);
                    browser.FindElement(By.Id("ef_autor")).SendKeys(item.NameAutor);

                    List<string> works = new List<string>();

                    browser.FindElement(By.XPath("//input[@value='Найти произведения']")).Click();
                    var t = browser.FindElements(By.XPath("//div[@class='search-results']/p[@style='margin-left:49px;margin-bottom:15px']/a"));
                    foreach (var ggg in t)
                    {
                        string[] fff = ggg.Text.Split(new char[] { '/' });
                        if (fff.Length < 1)
                            throw new Exception();
                        else
                        {
                            if (Regex.IsMatch(fff[0], Regex.Replace(item.Name, @"\.", ""), RegexOptions.IgnoreCase))
                            {
                                works.Add(ggg.GetAttribute("href"));
                            }
                        } 
                    }
                    if(works.Count==1)
                    {
                       var cvt = HttpWeb.Get($"https://api.fantlab.ru/work/{Regex.Match(works[0], @"(?<=work)(.*)").Value}/extended", 60000);
                        var tdf = JsonConvert.DeserializeObject<work>(cvt);
                        if (tdf.Classificatory != null && tdf.Classificatory.GenreGroup != null)
                        {
                            var dft = tdf.Classificatory.GenreGroup.Where(x => x.Label == "Жанры/поджанры").ToList();
                            if (dft.Count != 0 && dft.First().Genre != null)
                            {
                                foreach (var fgdf in dft.First().Genre)
                                {
                                    item.GenreFantLab += fgdf.Label + ",";
                                }
                                item.GenreFantLab = item.GenreFantLab.Trim(new char[] { ',' });
                                item.GenreFantLab = item.GenreFantLab.ToLower();
                                item.GenreFantLab = item.GenreFantLab.First().ToString().ToUpper() + item.GenreFantLab.Substring(1);
                            }
                        }
                        item.DescriptionFantLab = tdf.WorkDescription;
                        item.FantlabUrl = "https://fantlab.ru/work" + Regex.Match(works[0], @"(?<=work)(.*)").Value;


                        Console.WriteLine($"{item.Name} +");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} -");
                    }

                    readedOlegTables_Good.Add(item);

                }
                //@break++;
                //if (@break >= 10)
                //    break;
            }

            var res = new ReadedOleg().MyGetHead();
            foreach (var item in readedOlegTables_Good.Select(x => x.MyGetString()).ToList())
            {
                res += item;
            }
            InputOutputService.SaveTextInFile("MyOut.csv", res);

            Console.WriteLine("end");
        }


        
    }
}
