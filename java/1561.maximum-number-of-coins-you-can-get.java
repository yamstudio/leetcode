/*
 * @lc app=leetcode id=1561 lang=java
 *
 * [1561] Maximum Number of Coins You Can Get
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maxCoins(int[] piles) {
        Arrays.sort(piles);
        int ret = 0, n = piles.length / 3;
        for (int i = piles.length - 2; i >= n; i -= 2) {
            ret += piles[i];
        }
        return ret;
    }
}
// @lc code=end

