using EmpiricMethods_Lab1.DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Extensions
{
    public static class ValueRankSequenceExtensions
    {
        public static List<ValueRank> RelationalSort(this List<ValueRank> sourceRanks, List<ValueRank> toSortByRanks)
        {
            var copyToSortRanks = toSortByRanks.OrderBy(v => v.Rank).ToList();
            var sortedParallelRanks = copyToSortRanks.Select(e => sourceRanks[toSortByRanks.IndexOf(e)]).ToList();
            toSortByRanks.Clear();
            toSortByRanks.AddRange(copyToSortRanks);
            return sortedParallelRanks;
        }
    }
}
