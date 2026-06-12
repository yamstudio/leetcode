/*
 * @lc app=leetcode id=1769 lang=java
 *
 * [1769] Minimum Number of Operations to Move All Balls to Each Box
 */

// @lc code=start
class Solution {
    public int[] minOperations(String boxes) {
        int n = boxes.length(), c = 0, l = 0, p = 0;
        for (int i = 0; i < n; ++i) {
            int v = boxes.charAt(i) - '0';
            c += v;
            l += v * i;
        }
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int v = boxes.charAt(i) - '0';
            ret[i] = l;
            c -= v;
            p += v;
            l += p - c;
        }
        return ret;
    }
}
// @lc code=end

