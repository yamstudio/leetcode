/*
 * @lc app=leetcode id=1461 lang=csharp
 *
 * [1461] Check If a String Contains All Binary Codes of Size K
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool HasAllCodes(string s, int k) {
        var set = new HashSet<int>();
        int n = s.Length, acc = 0, mask = (1 << k) - 1;
        for (int i = 0; i < n; ++i) {
            acc = (acc << 1) & mask;
            if (s[i] == '1') {
                ++acc;
            }
            if (i >= k - 1) {
                set.Add(acc);
            }
        }
        return set.Count == (1 << k);
    }
}
// @lc code=end

