/*
 * @lc app=leetcode id=1689 lang=csharp
 *
 * [1689] Partitioning Into Minimum Number Of Deci-Binary Numbers
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MinPartitions(string n) {
        return n.Max(c => (int)c - (int)'0');
    }
}
// @lc code=end

