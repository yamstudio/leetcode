/*
 * @lc app=leetcode id=1539 lang=java
 *
 * [1539] Kth Missing Positive Number
 */

// @lc code=start
class Solution {
    public int findKthPositive(int[] arr, int k) {
        int l = 0, r = arr.length;
        while (l < r) {
            int m = (l + r) / 2, missing = arr[m] - (m + 1);
            if (missing < k) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return l + k;
    }
}
// @lc code=end

