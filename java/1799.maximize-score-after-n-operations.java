/*
 * @lc app=leetcode id=1799 lang=java
 *
 * [1799] Maximize Score After N Operations
 */

// @lc code=start
class Solution {
    public int maxScore(int[] nums) {
        int l = nums.length;
        int[][] gcd = new int[l][l];
        for (int i = 0; i < l; ++i) {
            for (int j = i + 1; j < l; ++j) {
                gcd[i][j] = gcd(nums[i], nums[j]);
            }
        }
        return maxScore(gcd, new int[l / 2][1 << l], 0, 0);
    }

    private static int maxScore(int[][] gcd, int[][] dp, int k, int m) {
        int l = gcd.length, n = l / 2;
        if (k == n) {
            return 0;
        }
        int ret = dp[k][m];
        if (ret != 0) {
            return ret;
        }
        for (int i = 0; i < l; ++i) {
            if ((m & (1 << i)) != 0) {
                continue;
            }
            for (int j = i + 1; j < l; ++j) {
                if ((m & (1 << j)) != 0) {
                    continue;
                }
                ret = Math.max(
                    ret,
                    (k + 1) * gcd[i][j] + maxScore(gcd, dp, k + 1, m | (1 << i) | (1 << j))
                );
            }
        }
        dp[k][m] = ret;
        return ret;
    }

    private static int gcd(int x, int y) {
        if (y == 0) {
            return x;
        }
        return gcd(y, x % y);
    }
}
// @lc code=end

