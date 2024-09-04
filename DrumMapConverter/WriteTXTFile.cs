using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DrumMapConverter
{
    public static class WriteTXTFile
    {
        public static void CreateFile(string txtFilePath, List<string> lines)
        {
            var DrumMapName = lines.FirstOrDefault();
            lines.Remove(lines.FirstOrDefault());

            using (StreamWriter writer = new StreamWriter(txtFilePath + DrumMapName + ".txt"))
            {
                writer.WriteLine("# MIDI note/CC name map");
                writer.WriteLine(DrumMapName);

                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine(DrumMapName + " File Created.");

        }

    }
}
