/*
 * @lc app=leetcode id=1734 lang=java
 *
 * [1734] Decode XORed Permutation
 */

// @lc code=start
class Solution {
    public int[] decode(int[] encoded) {
        int acc = 0, n = encoded.length + 1;
        int[] ret = new int[n];
        for (int i = 1; i <= n; ++i) {
            acc ^= i;
        }
        for (int i = 1; i < n - 1; i += 2) {
            acc ^= encoded[i];
        }
        ret[0] = acc;
        for (int i = 1; i < n; ++i) {
            ret[i] = encoded[i - 1] ^ ret[i - 1];
        }
        return ret;
    }
}
// @lc code=end

