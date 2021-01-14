/*
 * @lc app=leetcode id=775 lang=java
 *
 * [775] Global and Local Inversions
 */

// @lc code=start
class Solution {
    public boolean isIdealPermutation(int[] A) {
        int n = A.length, max = -1;
        for (int i = 2; i < n; ++i) {
            max = Math.max(max, A[i - 2]);
            if (max > A[i]) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

