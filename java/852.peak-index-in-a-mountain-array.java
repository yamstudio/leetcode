/*
 * @lc app=leetcode id=852 lang=java
 *
 * [852] Peak Index in a Mountain Array
 */

// @lc code=start
class Solution {
    public int peakIndexInMountainArray(int[] arr) {
        int l = 1, r = arr.length - 2;
        while (l < r) {
            int m = (l + r) / 2;
            if (arr[m] > arr[m - 1]) {
                if (arr[m] > arr[m + 1]) {
                    return m;
                }
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return l;
    }
}
// @lc code=end

