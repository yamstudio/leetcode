/*
 * @lc app=leetcode id=1753 lang=java
 *
 * [1753] Maximum Score From Removing Stones
 */

// @lc code=start
class Solution {
    public int maximumScore(int a, int b, int c) {
        return Math.min(
            a + b + c - Math.max(a, Math.max(b, c)),
            (a + b + c) / 2
        );
    }
}
// @lc code=end

