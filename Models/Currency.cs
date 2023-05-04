using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.Models
{

    public class Currency 
    {
        public String Id { get; set; } = String.Empty;
        public Int16 Rank { get; set; }
        public String Symbol { get; set; } = String.Empty;
        public String Name { get; set; } = String.Empty;
        public Decimal Supply { get; set; }
        public Decimal? MaxSupply { get; set; }
        public Decimal MarketCapUsd { get; set; }
        public Decimal VolumeUsd24Hr { get; set; }
        public Decimal PriceUsd { get; set; }
        public Decimal ChangePercent24Hr { get; set; }
        public Decimal? Vwap24Hr { get; set; }
        public String Explorer { get; set; } = String.Empty;
    }
}
