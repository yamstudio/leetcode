/*
 * @lc app=leetcode id=829 lang=java
 *
 * [829] Consecutive Numbers Sum
 */

// @lc code=start
class Solution {
    public int consecutiveNumbersSum(int N) {
        int ret = 0;
        for (int i = 1; (1 + i) * i / 2 <= N; ++i) {
            if ((N - i * (i - 1) / 2) % i == 0) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

