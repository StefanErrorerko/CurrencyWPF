using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.Models
{
    public class Exchange
    {
        public String ExchangeId {get;set;} = String.Empty;
        public String Name { get; set; } = String.Empty;
        public Int16 Rank { get; set; }
        public Decimal PercentTotalValue { get; set; }
        public Decimal VolumeUsd { get; set; }
        public Int16 TraidingPairs { get; set; }
        public String ExchangeUrl { get; set; } = String.Empty;
    }
}
