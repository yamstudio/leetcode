/*
 * @lc app=leetcode id=1647 lang=csharp
 *
 * [1647] Minimum Deletions to Make Character Frequencies Unique
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinDeletions(string s) {
        int ret = 0, p = int.MaxValue;
        foreach (int count in s
            .GroupBy(c => c, (c, a) => a.Count())
            .OrderByDescending(c => c)) {
            if (count < p) {
                p = count;
                continue;
            }
            if (p == 0) {
                ret += count;
                continue;
            }
            --p;
            ret += count - p;
        }
        return ret;
    }
}
// @lc code=end

