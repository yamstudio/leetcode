/*
 * @lc app=leetcode id=691 lang=csharp
 *
 * [691] Stickers to Spell Word
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int MinStickersRecurse(int[,] count, int n, int[] target, IDictionary<string, int> map) {
        string key = string.Join(",", target.Select(x => x.ToString()));
        int ret, f;
        if (map.TryGetValue(key, out ret)) {
            return ret;
        }
        ret = int.MaxValue;
        for (f = 0; f < 26 && target[f] == 0; ++f);
        for (int i = 0; i < n; ++i) {
            if (count[i, f] == 0) {
                continue;
            }
            int curr = MinStickersRecurse(count, n, Enumerable.Range(0, 26).Select(j => Math.Max(0, target[j] - count[i, j])).ToArray(), map);
            if (curr >= 0) {
                ret = Math.Min(ret, curr + 1);
            }
        }
        return (map[key] = ret == int.MaxValue ? -1 : ret);
    }

    public int MinStickers(string[] stickers, string target) {
        int n = stickers.Length;
        int[,] count = new int[n, 26];
        for (int i = 0; i < n; ++i) {
            foreach (char c in stickers[i]) {
                ++count[i, (int) c - (int) 'a'];
            } 
        }
        int[] t = new int[26];
        foreach (char c in target) {
            ++t[(int) c - (int) 'a'];
        }
        IDictionary<string, int> map = new Dictionary<string, int>();
        map[string.Join(",", Enumerable.Repeat("0", 26))] = 0;
        return MinStickersRecurse(count, n, t, map);
    }
}
// @lc code=end

