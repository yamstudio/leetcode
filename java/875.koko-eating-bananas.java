/*
 * @lc app=leetcode id=875 lang=java
 *
 * [875] Koko Eating Bananas
 */

// @lc code=start
class Solution {
    public int minEatingSpeed(int[] piles, int H) {
        int l = 1, r = 0;
        for (int p : piles) {
            r = Math.max(r, p);
        }
        while (l < r) {
            int m = (l + r) / 2, c = 0;
            for (int p : piles) {
                c += (p + m - 1) / m;
                if (c > H) {
                    break;
                }
            }
            if (c > H) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return l;
    }
}
// @lc code=end

