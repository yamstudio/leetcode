/*
 * @lc app=leetcode id=798 lang=java
 *
 * [798] Smallest Rotation with Highest Score
 */

// @lc code=start
class Solution {
    public int bestRotation(int[] A) {
        int n = A.length, mi = 0;
        int[] shift = new int[n];
        for (int i = 0; i < n; ++i) {
            shift[(i - A[i] + 1 + n) % n]--;
        }
        for (int i = 1; i < n; ++i) {
            shift[i] += 1 + shift[i - 1];
            if (shift[i] > shift[mi]) {
                mi = i;
            }
        }
        return mi;
    }
}
// @lc code=end

