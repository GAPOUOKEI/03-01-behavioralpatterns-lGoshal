using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingSystem
{
    class TextProcessor : ProcessingFile
    {
        protected override string CustomProcessing(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");
        }
    }
}
