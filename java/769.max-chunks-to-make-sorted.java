/*
 * @lc app=leetcode id=769 lang=java
 *
 * [769] Max Chunks To Make Sorted
 */

// @lc code=start
class Solution {
    public int maxChunksToSorted(int[] arr) {
        int n = arr.length, max = 0, ret = 0;
        for (int i = 0; i < n; ++i) {
            max = Math.max(max, arr[i]);
            if (max == i) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

