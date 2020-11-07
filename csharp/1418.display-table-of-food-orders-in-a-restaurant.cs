/*
 * @lc app=leetcode id=1418 lang=csharp
 *
 * [1418] Display Table of Food Orders in a Restaurant
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<IList<string>> DisplayTable(IList<IList<string>> orders) {
        var header = new List<string>();
        var foodMap = new Dictionary<string, int>();
        var tableMap = new Dictionary<string, IList<int>>();
        foreach (var order in orders) {
            string table = order[1], food = order[2];
            if (!foodMap.TryGetValue(food, out int fi)) {
                fi = header.Count;
                header.Add(food);
                foodMap[food] = fi;
            }
            if (!tableMap.TryGetValue(table, out var t)) {
                t = new List<int>();
                tableMap[table] = t;
            }
            while (t.Count <= fi) {
                t.Add(0);
            }
            t[fi]++;
        }
        header = header.OrderBy(f => f, StringComparer.Ordinal).ToList();
        var foodIndices = header
            .Select(f => foodMap[f])
            .ToArray();
        return tableMap
            .OrderBy(t => int.Parse(t.Key))
            .Select<KeyValuePair<string, IList<int>>, IList<string>>(t => foodIndices
                .Select(i => t.Value.Count > i ? t.Value[i].ToString() : "0")
                .Prepend(t.Key.ToString())
                .ToList())
            .Prepend(header.Prepend("Table").ToList())
            .ToList();
    }
}
// @lc code=end

