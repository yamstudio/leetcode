/*
 * @lc app=leetcode id=941 lang=java
 *
 * [941] Valid Mountain Array
 */

// @lc code=start
class Solution {
    public boolean validMountainArray(int[] arr) {
        int n = arr.length;
        if (n < 3) {
            return false;
        }
        if (arr[1] <= arr[0]) {
            return false;
        }
        boolean dec = false;
        for (int i = 2; i < n; ++i) {
            if (dec) {
                if (arr[i] >= arr[i - 1]) {
                    return false;
                }
            } else {
                if (arr[i] == arr[i - 1]) {
                    return false;
                }
                dec = arr[i] < arr[i - 1];
            }
        }
        return dec;
    }
}
// @lc code=end

