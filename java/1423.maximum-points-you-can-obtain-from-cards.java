/*
 * @lc app=leetcode id=1423 lang=java
 *
 * [1423] Maximum Points You Can Obtain from Cards
 */

// @lc code=start
class Solution {
    public int maxScore(int[] cardPoints, int k) {
        int n = cardPoints.length, acc = 0, ret;
        for (int i = 0; i < k; ++i) {
            acc += cardPoints[i];
        }
        ret = acc;
        for (int i = 0; i < k; ++i) {
            acc += cardPoints[n - 1 - i] - cardPoints[k - 1 - i];
            ret = Math.max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

