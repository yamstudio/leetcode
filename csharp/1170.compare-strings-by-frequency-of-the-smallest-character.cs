/*
 * @lc app=leetcode id=1170 lang=csharp
 *
 * [1170] Compare Strings by Frequency of the Smallest Character
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int GetFrequency(string word) {
        return word
            .GroupBy(c => c, (char c, IEnumerable<char> all) => (Letter: c, Count: all.Count()))
            .Min().Count;
    }

    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        var sorted = new List<(int Frequency, int Total)>();
        int m = queries.Length, n = words.Length, acc = 0;
        var ret = new int[m];
        var map = new Dictionary<int, int>();
        foreach (var word in words) {
            int f = GetFrequency(word);
            if (!map.TryGetValue(f, out int c)) {
                map[f] = 1;
            } else {
                map[f] = 1 + c;
            }
        }
        foreach (var t in map.OrderBy(k => k.Key)) {
            acc += t.Value;
            sorted.Add((Frequency: t.Key, Total: acc));
        }
        for (int i = 0; i < m; ++i) {
            int l = 0, r = sorted.Count, f = GetFrequency(queries[i]);
            while (l < r) {
                int mi = (l + r) / 2;
                if (sorted[mi].Frequency <= f) {
                    l = mi + 1;
                } else {
                    r = mi;
                }
            }
            if (l == 0) {
                ret[i] = n;
            } else {
                ret[i] = n - sorted[l - 1].Total;
            }
        }
        return ret;
    }
}
// @lc code=end

