/*
 * @lc app=leetcode id=1105 lang=java
 *
 * [1105] Filling Bookcase Shelves
 */

// @lc code=start
class Solution {
    public int minHeightShelves(int[][] books, int shelfWidth) {
        int n = books.length;
        int[] dp = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            int width = shelfWidth, h = 0;
            dp[i + 1] = Integer.MAX_VALUE;
            for (int j = i; j >= 0 && width >= books[j][0]; --j) {
                width -= books[j][0];
                h = Math.max(h, books[j][1]);
                dp[i + 1] = Math.min(dp[i + 1], dp[j] + h);
            }
        }
        return dp[n];
    }
}
// @lc code=end

