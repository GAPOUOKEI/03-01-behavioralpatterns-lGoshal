using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    interface IState
    {
        void ShowExchangeRates();
        void UpdateExchangeRates();
    }
}
