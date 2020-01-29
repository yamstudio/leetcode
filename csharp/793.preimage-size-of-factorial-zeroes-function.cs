/*
 * @lc app=leetcode id=793 lang=csharp
 *
 * [793] Preimage Size of Factorial Zeroes Function
 */

// @lc code=start
public class Solution {
    public int PreimageSizeFZF(int K) {
        long l = 0, r = (long)K * 5 + 5;
        while (l < r) {
            long m = l + (r - l) / 2;
            long count = 0;
            for (long x = m; x > 0; x /= 5) {
                count += x / 5;
            }
            if (count == (long)K) {
                return 5;
            }
            if (count < (long)K) {
                l = m +1;
            } else {
                r = m;
            }
        }
        return 0;
    }
}
// @lc code=end

