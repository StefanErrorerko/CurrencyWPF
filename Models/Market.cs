using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.Models
{
    public class Market
    {
        public String ExchangeId { get; set; } = String.Empty;
        public String Name { get; set; } = String.Empty;
        public String BaseId { get; set; } = String.Empty;
        public String QuoteId { get; set; } = String.Empty;
        public String BaseSymbol { get; set; } = String.Empty;
        public String QuoteSymbol { get; set; } = String.Empty;
        public Decimal VolumeUsd24Hr { get; set; } 
        public Decimal PriceUsd { get; set; }
        public Decimal VolumePercent { get; set; }
    }
}
