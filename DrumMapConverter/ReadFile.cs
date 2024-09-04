using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DrumMapConverter
{
    public static class ReadFile
    {
        public static List<string> ConvertToList(string xmlFilePath)
        {
            XDocument xmlDoc = XDocument.Load(xmlFilePath);

            var mapList = xmlDoc.Descendants("list")
                         .Where(x => (string)x.Attribute("name") == "Map")
                         .ToList();

            var nameDrumMap = xmlDoc.Descendants("string")
                             .FirstOrDefault(x => (string)x.Attribute("name") == "Name");

            string nameDrumMapValue = "";

            List<string> lines = new List<string>();

            if (nameDrumMap != null)
            {
                nameDrumMapValue = Utils.CleanStringFromSpecialsCharacters(nameDrumMap.Attribute("value")?.Value);
                lines.Add(nameDrumMapValue);
            }

            if (mapList != null)
            {
                    foreach (var item in mapList.Elements("item").Where(i => i.Element("string").Attribute("value").Value != ""))
                    {
                        var note = item.Element("int")?.Attribute("value")?.Value;
                        var instrument = item.Element("string")?.Attribute("value")?.Value;

                       lines.Add(note + " " + instrument);
                    }
            }
            else
            {
                Console.WriteLine("Error: Map list not found.");
            }

            return lines;

        }
    }


}
