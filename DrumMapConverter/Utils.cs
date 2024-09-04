using System;
using System.Collections.Generic;
using System.Text;

namespace DrumMapConverter
{
    public static class Utils
    {
        public static string CleanStringFromSpecialsCharacters(string stringToBeCleaned)
        {
            return stringToBeCleaned.Replace("/","-");
        }
    }
}
