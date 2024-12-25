/*
 * @lc app=leetcode id=1103 lang=java
 *
 * [1103] Distribute Candies to People
 */

// @lc code=start
class Solution {
    public int[] distributeCandies(int candies, int numPeople) {
        int m, k;
        for (k = 0, m = 0; (1 + m + numPeople) * (m + numPeople) / 2 <= candies; m += numPeople, ++k);
        int r = candies - (1 + m) * m / 2;
        int[] ret = new int[numPeople];
        for (int i = 1; i <= numPeople; ++i) {
            int s = Math.min(r, k * numPeople + i);
            ret[i - 1] = s + k * i + (k - 1) * k / 2 * numPeople;
            r -= s;
        }
        return ret;
    }
}
// @lc code=end

