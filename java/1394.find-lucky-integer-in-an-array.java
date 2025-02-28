/*
 * @lc app=leetcode id=1394 lang=java
 *
 * [1394] Find Lucky Integer in an Array
 */

// @lc code=start
class Solution {
    public int findLucky(int[] arr) {
        int n = arr.length;
        int[] count = new int[n + 1];
        for (int x : arr) {
            if (x > n) {
                continue;
            }
            ++count[x];
        }
        for (int i = n; i >= 1; --i) {
            if (i == count[i]) {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

