/*
 * @lc app=leetcode id=1566 lang=java
 *
 * [1566] Detect Pattern of Length M Repeated K or More Times
 */

// @lc code=start
class Solution {
    public boolean containsPattern(int[] arr, int m, int k) {
        int acc = 0, n = arr.length;
        for (int i = 0; i + m < n; ++i) {
            if (arr[i] == arr[i + m]) {
                if (++acc == (k - 1) * m) {
                    return true;
                }
            } else {
                acc = 0;
            }
        }
        return false;
    }
}
// @lc code=end

