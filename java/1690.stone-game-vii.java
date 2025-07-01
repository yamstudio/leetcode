/*
 * @lc app=leetcode id=1690 lang=java
 *
 * [1690] Stone Game VII
 */

// @lc code=start
class Solution {
    public int stoneGameVII(int[] stones) {
        int n = stones.length, sum = 0;
        for (int i = 0; i < n; ++i) {
            sum += stones[i];
        }
        return stoneGameVII(stones, 0, n - 1, sum, new Integer[n][n]);
    }

    private static int stoneGameVII(int[] stones, int l, int r, int sum, Integer[][] memo) {
        if (l == r) {
            return 0;
        }
        Integer m = memo[l][r];
        if (m != null) {
            return m;
        }
        int ret = Math.max(
            sum - stones[l] - stoneGameVII(stones, l + 1, r, sum - stones[l], memo),
            sum - stones[r] - stoneGameVII(stones, l, r - 1, sum - stones[r], memo)
        );
        memo[l][r] = ret;
        return ret;
    }
}
// @lc code=end

