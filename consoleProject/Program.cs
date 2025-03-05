namespace FileProcessingSystem
{
    /*
     * ФИО студента: Барсуков Владислав
     * номер варианта: 4
     * условие задачи: Создайте приложение для обработки текстовых файлов,
     *                 где различная предобработка
     *                 (например, очистка от комментариев, замена переносов строк и т.д.)
     *                 будет реализована как шаги шаблонного метода.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            // Имена входного и выходного файлов
            string InputFilePath = "input.txt";
            string OutputFilePath = "output.txt";

            ProcessingFile processing = new TextProcessor();
            processing.ProcessingText(InputFilePath, OutputFilePath);

            Console.WriteLine($"Обработка файла завешена. Результат записан в {OutputFilePath}");
        }
    }
}