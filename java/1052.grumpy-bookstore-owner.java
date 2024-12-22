/*
 * @lc app=leetcode id=1052 lang=java
 *
 * [1052] Grumpy Bookstore Owner
 */

// @lc code=start
class Solution {
    public int maxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int h = 0, n = customers.length, l = 0, g = 0, m = 0;
        for (int r = 0; r < n; ++r) {
            if (grumpy[r] == 0) {
                h += customers[r];
            } else {
                g += customers[r];
            }
            if (r - l + 1 > minutes) {
                if (grumpy[l] == 1) {
                    g -= customers[l];
                }
                ++l;
            }
            m = Math.max(m, g);
        }
        return m + h;
    }
}
// @lc code=end

