/*
 * @lc app=leetcode id=1758 lang=java
 *
 * [1758] Minimum Changes To Make Alternating Binary String
 */

// @lc code=start
class Solution {
    public int minOperations(String s) {
        int n = s.length(), d = 0;
        for (int i = 0; i < n; ++i) {
            d += (i % 2) ^ (s.charAt(i) - '0');
        }
        return Math.min(d, n - d);
    }
}
// @lc code=end

