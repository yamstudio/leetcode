/*
 * @lc app=leetcode id=1011 lang=java
 *
 * [1011] Capacity To Ship Packages Within D Days
 */

// @lc code=start
class Solution {
    public int shipWithinDays(int[] weights, int days) {
        int l = 0, r = 0;
        for (int w : weights) {
            r += w;
            l = Math.max(l, w);
        }
        while (l < r) {
            int m = (l + r) / 2, d = 1, acc = 0;
            for (int w : weights) {
                if (acc + w > m) {
                    ++d;
                    if (d > days) {
                        break;
                    }
                    acc = w;
                } else {
                    acc += w;
                }
            }
            if (d <= days) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
}
// @lc code=end

