/*
 * @lc app=leetcode id=1687 lang=csharp
 *
 * [1687] Delivering Boxes from Storage to Ports
 */

// @lc code=start
public class Solution {
    public int BoxDelivering(int[][] boxes, int portsCount, int maxBoxes, int maxWeight) {
        int n = boxes.Length, ports = 0, weight = 0, i = 0;
        var dp = new int[n + 1];
        for (int j = 0; j < n; ++j) {
            weight += boxes[j][1];
            if (j > 0 && boxes[j][0] != boxes[j - 1][0]) {
                ++ports;
            }
            while (j - i >= maxBoxes || weight > maxWeight || i < j && dp[i] == dp[i + 1]) {
                weight -= boxes[i][1];
                if (boxes[i][0] != boxes[i + 1][0]) {
                    --ports;
                }
                ++i;
            }
            dp[j + 1] = dp[i] + ports + 2;
        }
        return dp[n];
    }
}
// @lc code=end

