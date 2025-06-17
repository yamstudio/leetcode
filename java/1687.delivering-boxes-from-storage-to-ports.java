/*
 * @lc app=leetcode id=1687 lang=java
 *
 * [1687] Delivering Boxes from Storage to Ports
 */

// @lc code=start
class Solution {
    public int boxDelivering(int[][] boxes, int portsCount, int maxBoxes, int maxWeight) {
        int n = boxes.length, w = 0, l = 0, p = 0;
        int[] dp = new int[n + 1];
        for (int r = 0; r < n; ++r) {
            w += boxes[r][1];
            if (r > 0 && boxes[r][0] != boxes[r - 1][0]) {
                ++p;
            }
            while (w > maxWeight || r - l >= maxBoxes || (l < r && dp[l] == dp[l + 1])) {
                w -= boxes[l][1];
                if (boxes[l][0] != boxes[l + 1][0]) {
                    --p;
                }
                ++l;
            }
            dp[r + 1] = p + 2 + dp[l];
        }
        return dp[n];
    }
}
// @lc code=end

