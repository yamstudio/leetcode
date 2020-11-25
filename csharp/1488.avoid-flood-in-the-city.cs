/*
 * @lc app=leetcode id=1488 lang=csharp
 *
 * [1488] Avoid Flood in The City
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] AvoidFlood(int[] rains) {
        int n = rains.Length;
        int[] ret = new int[n];
        var dry = new SortedList<int, int>();
        var full = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            int rain = rains[i];
            if (rain == 0) {
                dry[i] = 0;
                continue;
            }
            ret[i] = -1;
            if (!full.TryGetValue(rain, out var j)) {
                full[rain] = i;
                continue;
            }
            IList<int> keys = dry.Keys;
            int k = keys.Count, l = 0, r = k;
            while (l < r) {
                int m = (l + r) / 2;
                if (keys[m] < j) {
                    l = m + 1;
                } else {
                    r = m;
                }
            }
            if (l == k) {
                return new int[0];
            }
            ret[keys[l]] = rain;
            dry.Remove(keys[l]);
            full[rain] = i;
        }
        foreach (var j in dry.Keys) {
            ret[j] = 2020;
        }
        return ret;
    }
}
// @lc code=end

