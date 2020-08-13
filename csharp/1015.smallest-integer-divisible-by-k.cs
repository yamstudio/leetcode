/*
 * @lc app=leetcode id=1015 lang=csharp
 *
 * [1015] Smallest Integer Divisible by K
 */

// @lc code=start
public class Solution {
    public int SmallestRepunitDivByK(int K) {
        if (K % 2 == 0 || K % 5 == 0) {
            return -1;
        }
        int d = 0;
        for (int i = 1; i <= K; ++i) {
            d = (1 + d * 10) % K;
            if (d % K == 0) {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

