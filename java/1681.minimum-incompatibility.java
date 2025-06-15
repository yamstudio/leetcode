/*
 * @lc app=leetcode id=1681 lang=java
 *
 * [1681] Minimum Incompatibility
 */

// @lc code=start
class Solution {
    public int minimumIncompatibility(int[] nums, int k) {
        int n = nums.length, size = n / k, t = 1 << n;
        int[] incomps = new int[t];
        for (int comb = 1; comb < t; ++comb) {
            int count = 0, c = comb;
            while (c > 0) {
                count += c & 1;
                c >>= 1;
            }
            if (count != size) {
                incomps[comb] = -1;
                continue;
            }
            int i, seen = 0, min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
            for (i = 0; i < n; ++i) {
                if (((1 << i) & comb) == 0) {
                    continue;
                }
                int v = nums[i];
                if (((1 << v) & seen) != 0) {
                    break;
                }
                seen |= 1 << v;
                min = Math.min(min, v);
                max = Math.max(max, v);
            }
            incomps[comb] = i == n ? (max - min) : -1;
        }
        int[] dp = new int[t];
        for (int comb = 1; comb < t; ++comb) {
            int count = 0, c = comb;
            while (c > 0) {
                count += c & 1;
                c >>= 1;
            }
            if (count % size != 0) {
                dp[comb] = -1;
                continue;
            }
            dp[comb] = Integer.MAX_VALUE;
            for (int m = comb; m != 0; m = comb & (m - 1)) {
                int o = comb ^ m;
                if (incomps[m] < 0 || dp[o] < 0) {
                    continue;
                }
                dp[comb] = Math.min(dp[comb], dp[o] + incomps[m]);
            }
            if (dp[comb] == Integer.MAX_VALUE) {
                dp[comb] = -1;
            }
        }
        return dp[t - 1];
    }
}
// @lc code=end

