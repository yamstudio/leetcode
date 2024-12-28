/*
 * @lc app=leetcode id=1137 lang=java
 *
 * [1137] N-th Tribonacci Number
 */

// @lc code=start
class Solution {
    public int tribonacci(int n) {
        int[] tri = new int[] { 0, 1, 1 };
        for (int i = 3; i <= n; ++i) {
            tri[i % 3] += tri[(i + 1) % 3] + tri[(i + 2) % 3];
        }
        return tri[n % 3];
    }
}
// @lc code=end

