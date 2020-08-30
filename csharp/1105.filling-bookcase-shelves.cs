/*
 * @lc app=leetcode id=1105 lang=csharp
 *
 * [1105] Filling Bookcase Shelves
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinHeightShelves(int[][] books, int shelf_width) {
        int n = books.Length;
        var dp = Enumerable.Repeat(int.MaxValue, n).Prepend(0).ToArray();
        for (int i = 0; i < n; ++i) {
            int width = shelf_width, h = 0;
            for (int j = i; j >= 0 && width >= books[j][0]; --j) {
                h = Math.Max(h, books[j][1]);
                width -= books[j][0];
                dp[i + 1] = Math.Min(dp[i + 1], dp[j] + h);
            }
        }
        return dp[n];
    }
}
// @lc code=end

