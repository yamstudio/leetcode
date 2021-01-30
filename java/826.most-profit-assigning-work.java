/*
 * @lc app=leetcode id=826 lang=java
 *
 * [826] Most Profit Assigning Work
 */

// @lc code=start
class Solution {
    public int maxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        int n = difficulty.length, ret = 0, j = 0, k = worker.length;
        int[][] sorted = new int[n + 2][];
        for (int i = 0; i < n; ++i) {
            sorted[i] = new int[] { difficulty[i], profit[i] };
        }
        sorted[n] = new int[] { 0, 0 };
        sorted[n + 1] = new int[] { 1000000, 0 };
        Arrays.sort(sorted, (t1, t2) -> Integer.compare(t1[0], t2[0]));
        for (int i = 1; i <= n; ++i) {
            sorted[i][1] = Math.max(sorted[i][1], sorted[i - 1][1]);
        }
        Arrays.sort(worker);
        for (int i = 0; i < k; ++i) {
            while (worker[i] >= sorted[j][0]) {
                ++j;
            }
            ret += sorted[j - 1][1];
        }
        return ret;
    }
}
// @lc code=end

