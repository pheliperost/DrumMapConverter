using System;
using System.IO;

namespace DrumMapConverter
{
    static class ConvertFiles{
        public static void Run()
        {
            try
            {
                Console.WriteLine("=== Process started ===");

                string[] files = Directory.GetFiles(FilesPath.SourcePath);

                foreach (var file in files)
                {
                    var lines = ReadFile.ConvertToList(file);
                    WriteTXTFile.CreateFile(FilesPath.DestinationPath, lines);
                }

                Console.WriteLine("=== Process finished ===");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
            }
        }
    }
}
