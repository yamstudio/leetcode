/*
 * @lc app=leetcode id=1406 lang=java
 *
 * [1406] Stone Game III
 */

// @lc code=start
class Solution {
    public String stoneGameIII(int[] stoneValue) {
        int n = stoneValue.length;
        int[] memo = new int[n];
        for (int i = 0; i < n; ++i) {
            memo[i] = Integer.MIN_VALUE;
        }
        int diff = diff(stoneValue, memo, 0);
        return diff > 0 ? "Alice" : (diff == 0 ? "Tie" : "Bob");
    }

    private static int diff(int[] stoneValue, int[] memo, int i) {
        int n = stoneValue.length;
        if (i == n) {
            return 0;
        }
        int ret = memo[i];
        if (ret != Integer.MIN_VALUE) {
            return ret;
        }
        int acc = 0;
        for (int k = 0; k < 3 && i + k < n; ++k) {
            acc += stoneValue[i + k];
            ret = Math.max(ret, acc - diff(stoneValue, memo, i + k + 1));
        }
        memo[i] = ret;
        return ret;
    }
}
// @lc code=end

