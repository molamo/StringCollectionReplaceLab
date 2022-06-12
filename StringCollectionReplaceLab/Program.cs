using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace StringCollectionReplace
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();
           
            var _pairs = configuration.GetSection("ReplaceSettings").Get<List<ReplaceSetting>>();
            
            var filePath = configuration.GetValue<string>("FilePath");
            string[] lines = File.ReadAllLines(filePath);
            
            List<string> result = new List<string>();
            var tempString = "";
            foreach (string line in lines)
            {
                if (line.Contains("Dialogue:"))
                {
                    string temp = line;
                    foreach (var item in _pairs)
                    {
                        temp = temp.Replace(item.find, item.replace);
                    }
                    tempString = temp;
                    //tempString = line.Replace('?', '？').Replace(" ", "　").Replace("!", "！").Replace("~", "～").Replace("[", "「").Replace("]", "」");
                }
                else
                {
                    tempString = line;
                }

                Console.WriteLine("\t" + tempString);
                result.Add(tempString);
            }

            FileInfo fileInfo = new FileInfo(filePath);
            var newFilePath = fileInfo.Directory.FullName + fileInfo.Name + "_After" + fileInfo.Extension;
            File.WriteAllLines(newFilePath, result.ToArray(),Encoding.UTF8);
        }
    }
}
