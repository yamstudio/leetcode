/*
 * @lc app=leetcode id=1535 lang=java
 *
 * [1535] Find the Winner of an Array Game
 */

// @lc code=start

class Solution {
    public int getWinner(int[] arr, int k) {
        int n = arr.length, max = arr[0], count = 0;
        for (int i = 1; i < n && count < k; ++i, ++count) {
            if (arr[i] > max) {
                count = 0;
                max = arr[i];
            }
        }
        return max;
    }
}
// @lc code=end

