/*
 * @lc app=leetcode id=936 lang=csharp
 *
 * [936] Stamping The Sequence
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] MovesToStamp(string stamp, string target) {
        var ret = new List<int>();
        bool placed = true;
        int n = stamp.Length, replaced = 0;
        while (placed) {
            placed = false;
            for (int len = n; len > 0; --len) {
                for (int i = 0; i + len <= n; ++i) {
                    string masked = new string('*', i) + stamp.Substring(i, len) + new string('*', n - i - len);
                    int j;
                    while ((j = target.IndexOf(masked)) >= 0) {
                        placed = true;
                        replaced += len;
                        ret.Add(j);
                        target = target.Substring(0, j) + new string('*', n) + target.Substring(j + n);
                    }
                }
            }
        }
        if (replaced != target.Length) {
            return new int[0];
        }
        return Enumerable.Reverse(ret).ToArray();
    }
}
// @lc code=end

