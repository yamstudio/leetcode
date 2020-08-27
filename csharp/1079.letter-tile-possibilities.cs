/*
 * @lc app=leetcode id=1079 lang=csharp
 *
 * [1079] Letter Tile Possibilities
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static int NumTilePossibilitiesRecurse(int[] count, IDictionary<string, int> memo) {
        string key = string.Join(',', count.OrderBy(x => x).Select(x => x.ToString()));
        if (memo.TryGetValue(key, out int ret)) {
            return ret;
        }
        ret = 1;
        for (int i = 0; i < count.Length; ++i) {
            if (count[i] == 0) {
                continue;
            }
            count[i]--;
            ret += NumTilePossibilitiesRecurse(count, memo);
            count[i]++;
        }
        memo[key] = ret;
        return ret;
    }

    public int NumTilePossibilities(string tiles) {
        return NumTilePossibilitiesRecurse(tiles
            .GroupBy(c => c, (char c, IEnumerable<char> all) => (Key: (int)c - (int)'A', Count: all.Count()))
            .OrderBy(t => t.Key)
            .Select(t => t.Count)
            .ToArray(), new Dictionary<string, int>()) - 1;
    }
}
// @lc code=end

