/*
 * @lc app=leetcode id=1806 lang=java
 *
 * [1806] Minimum Number of Operations to Reinitialize a Permutation
 */

// @lc code=start
class Solution {
    public int reinitializePermutation(int n) {
        int ret = 0, i = 1;
        do {
            ++ret;
            i = i < n / 2 ? (i * 2) : ((i - n / 2) * 2 + 1);
        } while (i != 1);
        return ret;
    }
}
// @lc code=end

