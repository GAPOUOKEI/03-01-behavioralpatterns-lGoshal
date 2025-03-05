using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class ExchangeRateContext
    {
        private IState _currentState;
        // Словарь валют
        private Dictionary<string, decimal> _exchangeRates;

        public ExchangeRateContext()
        {
            _currentState = new ViewMode(this);
            _exchangeRates = new Dictionary<string, decimal>
            {
                { "USD", 75.0m},
                { "EUR", 85.0m},
                { "GBP", 95.0m}
            };
        }

        public void SetState(IState newState) => _currentState = newState;

        public void ShowExchangeRates() => _currentState.ShowExchangeRates();

        public void UpdateExcangeRates() => _currentState.UpdateExchangeRates();

        public Dictionary<string, decimal> GetSavedRates()
        {
            return _exchangeRates;
        }

        // Попытка сделать обновлению валют
        public void UpdateRates()
        {
            var random = new Random();
            _exchangeRates["USD"] = Math.Round(70 + (decimal)random.NextDouble() * 10, 2);
            _exchangeRates["EUR"] = Math.Round(70 + (decimal)random.NextDouble() * 10, 2);
            _exchangeRates["GBP"] = Math.Round(70 + (decimal)random.NextDouble() * 10, 2);
        }
    }
}
