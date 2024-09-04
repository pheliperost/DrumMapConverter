using Microsoft.Extensions.Configuration;
using System;

namespace DrumMapConverter
{
    public static class FilesPath
    {
        public static string SourcePath { get; set; }
        public static string DestinationPath { get; set; }

        static FilesPath(){
          var configuration = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory) // Sets the base path to the application's directory
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            SourcePath = configuration["Path:SourcePath"];
            DestinationPath = configuration["Path:DestinationPath"];
        }
    }
}
