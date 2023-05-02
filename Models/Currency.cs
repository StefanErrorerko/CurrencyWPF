using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.Models
{
    class Currency
    {
        public String Id { get; set; } = String.Empty;
        public Int16 Rank { get; set; }
        public String Symbol { get; set; } = String.Empty;
        public String Name { get; set; } = String.Empty;
        public Decimal Supply { get; set; }
        public Decimal MaxSupply { get; set; }
        public Decimal MarketCapUsd { get; set; }
        public Decimal VolumeUsd24Hr { get; set; }
        public Decimal PriceUsd { get; set; }
        public Decimal ChangePrcnt24Hr { get; set; }
        public Decimal Vwap24Hr { get; set; }

        public Currency() { }
        public Currency(String id, 
            Int16 rank, 
            String symbol, 
            String name, 
            Decimal supply, 
            Decimal maxSupply, 
            Decimal marketCapUsd, 
            Decimal volumeUsd24Hr, 
            Decimal priceUsd, 
            Decimal changePrcnt24Hr, 
            Decimal vwap24Hr)
        {
            Id = id;
            Rank = rank;
            Symbol = symbol;
            Name = name;
            Supply = supply;
            MaxSupply = maxSupply;
            MarketCapUsd = marketCapUsd;
            VolumeUsd24Hr = volumeUsd24Hr;
            PriceUsd = priceUsd;
            ChangePrcnt24Hr = changePrcnt24Hr;
            Vwap24Hr = vwap24Hr;
        }
    }
}
