/*
 * @lc app=leetcode id=915 lang=java
 *
 * [915] Partition Array into Disjoint Intervals
 */

// @lc code=start
class Solution {
    public int partitionDisjoint(int[] A) {
        int n = A.length, lm = Integer.MIN_VALUE;
        int[] rm = new int[n];
        rm[n - 1] = A[n - 1];
        for (int i = n - 2; i > 0; --i) {
            rm[i] = Math.min(A[i], rm[i + 1]);
        }
        for (int i = 0; i < n - 1; ++i) {
            lm = Math.max(A[i], lm);
            if (lm <= rm[i + 1]) {
                return i + 1;
            }
        }
        return -1;
    }
}
// @lc code=end

