/*
 * @lc app=leetcode id=805 lang=java
 *
 * [805] Split Array With Same Average
 */

// @lc code=start
class Solution {
    public boolean splitArraySameAverage(int[] A) {
        int n = A.length, half = n / 2, sum = 0;
        for (int x : A) {
            sum += x;
        }
        boolean canSplit = false;
        for (int i = 1; i <= half && !canSplit; ++i) {
            canSplit = (sum * i % n == 0);
        }
        if (!canSplit) {
            return false;
        }
        Set<Integer>[] dp = new Set[half + 1];
        for (int i = 0; i <= half; ++i) {
            dp[i] = new HashSet<Integer>();
        }
        dp[0].add(0);
        for (int x : A) {
            for (int i = half; i > 0; --i) {
                for (int s : dp[i - 1]) {
                    dp[i].add(s + x);
                }
            }
        }
        for (int i = 1; i <= half; ++i) {
            if (sum * i % n == 0 && dp[i].contains(sum * i / n)) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

