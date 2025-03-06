using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class UpdateMode : IState
    {
        private readonly ExchangeRateContext _context;

        public UpdateMode(ExchangeRateContext context) => _context = context;

        public void ShowExchangeRates() => Console.WriteLine("Режим обновления данных. Просмотр курсов недоступен.");

        // Вызывать 2 раза
        public void UpdateExchangeRates()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Обновление курсов валют...");
            _context.UpdateRates();
            Console.WriteLine("Курсы обновлены. Переключение в режим просмотра.");
            _context.SetState(new ViewMode(_context));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
