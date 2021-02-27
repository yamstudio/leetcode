/*
 * @lc app=leetcode id=896 lang=java
 *
 * [896] Monotonic Array
 */

// @lc code=start
class Solution {
    public boolean isMonotonic(int[] A) {
        boolean inc = true, dec = true;
        int n = A.length;
        for (int i = 1; i < n; ++i) {
            inc &= A[i] >= A[i - 1];
            dec &= A[i] <= A[i - 1];
        }
        return dec || inc;
    }
}
// @lc code=end

