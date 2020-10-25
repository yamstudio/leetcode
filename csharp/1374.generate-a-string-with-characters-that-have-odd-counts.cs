/*
 * @lc app=leetcode id=1374 lang=csharp
 *
 * [1374] Generate a String With Characters That Have Odd Counts
 */

// @lc code=start
public class Solution {
    public string GenerateTheString(int n) {
        return n % 2 == 0 ? $"{new string('a', n - 1)}b" : new string('a', n);
    }
}
// @lc code=end

