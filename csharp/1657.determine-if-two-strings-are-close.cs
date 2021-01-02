/*
 * @lc app=leetcode id=1657 lang=csharp
 *
 * [1657] Determine if Two Strings Are Close
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool CloseStrings(string word1, string word2) {
        int m = word1.Length;
        if (m != word2.Length) {
            return false;
        }
        int[,] counts = new int[26, 2];
        for (int i = 0; i < m; ++i) {
            ++counts[(int)word1[i] - (int)'a', 0];
            ++counts[(int)word2[i] - (int)'a', 1];
        }
        var map = new Dictionary<int, int>();
        for (int i = 0; i < 26; ++i) {
            int c1 = counts[i, 0], c2 = counts[i, 1];
            if (c1 != 0 ^ c2 != 0) {
                return false;
            }
            if (c1 != 0) {
                if (map.TryGetValue(c1, out var v1)) {
                    map[c1] = v1 + 1;
                } else {
                    map[c1] = 1;
                }
                if (map.TryGetValue(c2, out var v2)) {
                    map[c2] = v2 - 1;
                } else {
                    map[c2] = -1;
                }
            }
        }
        return map.Values.All(x => x == 0);
    }
}
// @lc code=end

