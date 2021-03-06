/*
 * @lc app=leetcode id=905 lang=java
 *
 * [905] Sort Array By Parity
 */

// @lc code=start
class Solution {
    public int[] sortArrayByParity(int[] A) {
        int n = A.length, l = 0;
        for (int i = 0; i < n; ++i) {
            int c = A[i];
            if (c % 2 == 1) {
                continue;
            }
            A[i] = A[l];
            A[l++] = c;
        }
        return A;
    }
}
// @lc code=end

