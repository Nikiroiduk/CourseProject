using CourseProjectBL.Enum;
using System.Collections.Generic;

namespace CourseProjectBL.Dictionary
{
    public static class CurrencyDictionary
    {
        public static readonly Dictionary<Currency, string> currencySymbolsDictionary = new()
        {
            { Currency.USD, "$" },
            { Currency.EUR, "€" },
            { Currency.JPY, "¥" },
            { Currency.GBP, "£" },
            { Currency.AUD, "$" },
            { Currency.CAD, "$" },
            { Currency.CNY, "¥" },
            { Currency.HKD, "$" },
            { Currency.NZD, "$" },
            { Currency.SEK, "kr" },
            { Currency.KRW, "₩" },
            { Currency.INR, "₹" },
            { Currency.RUB, "₽" },
            { Currency.CZK, "Kč" },
            { Currency.UAH, "₴" },
        };
    }
}
