/*
 * @lc app=leetcode id=1492 lang=csharp
 *
 * [1492] The kth Factor of n
 */

// @lc code=start
public class Solution {
    public int KthFactor(int n, int k) {
        int d;
        for (d = 1; d * d <= n; ++d) {
            if (n % d == 0 && --k == 0) {
                return d;
            }
        }
        while (d * d >= n) {
            --d;
        }
        for (; d > 0; --d) {
            if (n % d == 0 && --k == 0) {
                return n / d;
            }
        }
        return -1;
    }
}
// @lc code=end

