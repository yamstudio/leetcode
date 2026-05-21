/*
 * @lc app=leetcode id=1744 lang=java
 *
 * [1744] Can You Eat Your Favorite Candy on Your Favorite Day?
 */

// @lc code=start
class Solution {
    public boolean[] canEat(int[] candiesCount, int[][] queries) {
        int n = candiesCount.length;
        long[] prev = new long[n];
        for (int i = 1; i < n; ++i) {
            prev[i] = prev[i - 1] + (long)candiesCount[i - 1];
        }
        int q = queries.length;
        boolean[] ret = new boolean[q];
        for (int i = 0; i < q; ++i) {
            int[] query = queries[i];
            int favIndex = query[0];
            long favDay = (long)query[1],
                cap = (long)query[2],
                min = prev[favIndex] / cap,
                max = prev[favIndex] + (long)candiesCount[favIndex] - 1;
            ret[i] = favDay >= min && favDay <= max;
        }
        return ret;
    }
}
// @lc code=end

