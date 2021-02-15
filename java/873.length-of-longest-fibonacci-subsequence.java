/*
 * @lc app=leetcode id=873 lang=java
 *
 * [873] Length of Longest Fibonacci Subsequence
 */

// @lc code=start
class Solution {
    public int lenLongestFibSubseq(int[] arr) {
        int n = arr.length, ret = 0;
        int[][] dp = new int[n][n];
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        for (int j = 0; j < n; ++j) {
            map.put(arr[j], j);
            for (int i = j - 1; i >= 0; --i) {
                int d = arr[j] - arr[i];
                if (d >= arr[i]) {
                    dp[i][j] = 2;
                    continue;
                }
                int p = map.getOrDefault(d, -1);
                if (p < 0) {
                    dp[i][j] = 2;
                } else {
                    dp[i][j] = 1 + dp[p][i];
                    ret = Math.max(ret, dp[i][j]);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

