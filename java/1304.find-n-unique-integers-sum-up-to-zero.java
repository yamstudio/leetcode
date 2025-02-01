/*
 * @lc app=leetcode id=1304 lang=java
 *
 * [1304] Find N Unique Integers Sum up to Zero
 */

// @lc code=start
class Solution {
    public int[] sumZero(int n) {
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            ret[i] = (i / 2 + 1) * (i % 2 == 0 ? 1 : -1);
        }
        if (n % 2 == 1) {
            ret[n - 1] = 0;
        }
        return ret;
    }
}
// @lc code=end

