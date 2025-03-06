using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class ViewMode : IState
    {
        private readonly ExchangeRateContext _context;
        public ViewMode(ExchangeRateContext context) => _context = context;

        public void ShowExchangeRates()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Текущие курсы валют:");
            foreach (var rate in _context.GetSavedRates())
            {
                Console.WriteLine($"{rate.Key}: {rate.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void UpdateExchangeRates()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Переключение в режим обновления данных...");
            _context.SetState(new UpdateMode(_context));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
