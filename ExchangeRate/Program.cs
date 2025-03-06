namespace ExchangeRate
{
    /*
     * ФИО студента: Барсуков Владислав
     * номер варианта: 4
     * условие задачи: Напишите программу, которая курсы валют и меняет
     *                 свое состояние зависимости от того, активен ли режим 
     *                 обновления данных или просмотра сохраненных значений.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ExchangeRateContext();

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Показать кусы валют");
                Console.WriteLine("2 - Обновить курсы валют");
                Console.WriteLine("3 - Выйти");
                Console.Write("Ваш выбор: ");

                var sw = Console.ReadLine();

                switch (sw)
                {
                    case "1":
                        context.ShowExchangeRates();
                        break;
                    case "2":
                        context.UpdateExcangeRates();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невеный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
