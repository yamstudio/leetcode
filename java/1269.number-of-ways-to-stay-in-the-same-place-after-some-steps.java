/*
 * @lc app=leetcode id=1269 lang=java
 *
 * [1269] Number of Ways to Stay in the Same Place After Some Steps
 */

// @lc code=start
class Solution {
    public int numWays(int steps, int arrLen) {
        int n = Math.min(arrLen, steps / 2 + 1);
        int[] prev = new int[n], curr = new int[n];
        prev[0] = 1;
        while (steps-- > 0) {
            for (int i = 0; i < n; ++i) {
                int count = prev[i];
                if (i > 0) {
                    count = (count + prev[i - 1]) % 1000000007;
                }
                if (i < n - 1) {
                    count = (count + prev[i + 1]) % 1000000007;
                }
                curr[i] = count;
            }
            int[] t = curr;
            curr = prev;
            prev = t;
        }
        return prev[0];
    }
}
// @lc code=end

