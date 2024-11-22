/*
 * @lc app=leetcode id=932 lang=java
 *
 * [932] Beautiful Array
 */

// @lc code=start
class Solution {
    public int[] beautifulArray(int n) {
        int[] ret = new int[] { 1 };
        while (ret.length < n) {
            int[] tmp = new int[Math.min(2 * ret.length, n)];
            int j = 0;
            for (int i = 0; i < ret.length; ++i) {
                int x = 2 * ret[i] - 1;
                if (x <= n) {
                    tmp[j++] = x;
                }
            }
            for (int i = 0; i < ret.length; ++i) {
                int x = 2 * ret[i];
                if (x <= n) {
                    tmp[j++] = x;
                }
            }
            ret = tmp;
        }
        return ret;
    }
}
// @lc code=end

