/*
 * @lc app=leetcode id=910 lang=java
 *
 * [910] Smallest Range II
 */

// @lc code=start
class Solution {
    public int smallestRangeII(int[] A, int K) {
        int max, n = A.length, ret;
        Arrays.sort(A);
        max = A[n - 1];
        ret = A[n - 1] - A[0];
        for (int i = 1; i < n; ++i) {
            max = Math.max(max, A[i - 1] + 2 * K);
            ret = Math.min(ret, max - Math.min(A[i], A[0] + 2 * K));
        }
        return ret;
    }
}
// @lc code=end

