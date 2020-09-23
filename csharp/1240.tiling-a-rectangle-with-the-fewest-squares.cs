/*
 * @lc app=leetcode id=1240 lang=csharp
 *
 * [1240] Tiling a Rectangle with the Fewest Squares
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static void TilingRectangleRecurse(int n, int m, int[] heights, int count, IDictionary<string, int> memo, ref int ret) {
        if (count >= ret) {
            return;
        }
        int min = m, l = -1, r;
        for (int i = 0; i < n; ++i) {
            if (heights[i] < min) {
                l = i;
                min = heights[i];
            }
        }
        if (l < 0) {
            ret = Math.Min(ret, count);
            return;
        }
        var key = string.Join('|', heights.Select(x => x.ToString()).ToArray());
        if (memo.TryGetValue(key, out int oc) && oc <= count) {
            return;
        }
        memo[key] = count;
        for (r = l; r < n - 1 && min == heights[r + 1] && r + 2 - l <= m - min; ++r);
        for (int i = r; i >= l; --i) {
            int len = i - l + 1;
            for (int j = 0; j < len; ++j) {
                heights[l + j] += len;
            }
            TilingRectangleRecurse(n, m, heights, count + 1, memo, ref ret);
            for (int j = 0; j < len; ++j) {
                heights[l + j] -= len;
            }
        }
    }
    
    public int TilingRectangle(int n, int m) {
        if (n == m) {
            return 1;
        }
        if (n > m) {
            int t = m;
            m = n;
            n = t;
        }
        int ret = m * n;
        TilingRectangleRecurse(n, m, new int[n], 0, new Dictionary<string, int>(), ref ret);
        return ret;
    }
}
// @lc code=end

