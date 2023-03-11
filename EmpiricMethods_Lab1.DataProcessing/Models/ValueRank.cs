using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.DataProcessing.Models
{
    public class ValueRank
    {
        public ValueRank()
        {
            Value = default;
            Rank = null;
            AmountInBundle = default;
        }
        public double Value { get; set; }
        public double? Rank { get; set; }
        public int AmountInBundle { get; set; }
        public bool HasBundle => AmountInBundle > 1;

        public static ValueRank Empty()
        {
            return new ValueRank();
        }
    }
}
