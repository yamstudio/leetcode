/*
 * @lc app=leetcode id=1720 lang=java
 *
 * [1720] Decode XORed Array
 */

// @lc code=start
class Solution {
    public int[] decode(int[] encoded, int first) {
        int n = encoded.length;
        int[] ret = new int[n + 1];
        ret[0] = first;
        for (int i = 1; i <= n; ++i) {
            ret[i] = ret[i - 1] ^ encoded[i - 1];
        }
        return ret;
    }
}
// @lc code=end

