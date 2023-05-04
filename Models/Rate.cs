using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.Models
{
    public enum RateType
    {
        Fiat,
        Crypto
    }
    public class Rate
    {
        public String Id { get; set; } = String.Empty;
        public String Symbol { get; set; } = String.Empty;
        public String CurrencySymbol { get; set; } = String.Empty;
        public RateType Type { get; set; }
        public Decimal RateUsd { get; set; }
    }
}
