/*
 * @lc app=leetcode id=891 lang=java
 *
 * [891] Sum of Subsequence Widths
 */

// @lc code=start
class Solution {
    public int sumSubseqWidths(int[] A) {
        long t = 1, ret = 0;
        int n = A.length;
        Arrays.sort(A);
        for (int i = 0; i < n; ++i) {
            ret = (ret + (long)A[i] * t - (long)A[n - 1 - i] * t) % 1000000007;
            t = (t * 2) % 1000000007;
        }
        return (int)((ret + 1000000007) % 1000000007);
    }
}
// @lc code=end

