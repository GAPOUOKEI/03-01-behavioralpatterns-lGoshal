using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileProcessingSystem
{
    abstract class ProcessingFile
    {
        // Основной метод
        public void ProcessingText(string InputFilePath, string OutputFilePath)
        {
            string text = FileReader(InputFilePath);
            text = CommentRemover(text);
            text = LineEndReplacer(text);
            text = CustomProcessing(text);
            WriteFile(OutputFilePath, text);
        }

        // Метод на чтение файла
        protected string FileReader(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.UTF8);
        }

        // Метод на запись в файл
        protected void WriteFile(string FilePath, string text)
        {
            File.WriteAllText(FilePath, text, Encoding.UTF8);
        }

        // Метод заменяющий комментарии
        protected string CommentRemover(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, @"//.*", "");
        }

        // Метод заменяющий переносы
        protected string LineEndReplacer(string text)
        {
            return text.Replace(Environment.NewLine, " ");
        }

        // Заготовка на дальнейшую обработку
        protected abstract string CustomProcessing(string text);
    }
}
