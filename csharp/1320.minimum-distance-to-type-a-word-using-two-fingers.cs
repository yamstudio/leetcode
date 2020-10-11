/*
 * @lc app=leetcode id=1320 lang=csharp
 *
 * [1320] Minimum Distance to Type a Word Using Two Fingers
 */

using System;

// @lc code=start
public class Solution {

    private static int GetCost(int f, int t) {
        if (f == 26) {
            return 0;
        }
        return Math.Abs(f % 6 - t % 6) + Math.Abs(f / 6 - t / 6);
    }

    private static int MinimumDistanceRecurse(string word, int n, int i, int[,,] memo, int l, int r) {
        if (i >= n) {
            return 0;
        }
        if (memo[l, r, i] == 0) {
            int t = (int)word[i] - 'A';
            memo[l, r, i] = 1 + Math.Min(GetCost(l, t) + MinimumDistanceRecurse(word, n, i + 1, memo, t, r), GetCost(r, t) + MinimumDistanceRecurse(word, n, i + 1, memo, l, t));
        }
        return memo[l, r, i] - 1;
    }

    public int MinimumDistance(string word) {
        int n = word.Length;
        return MinimumDistanceRecurse(word, n, 0, new int[27, 27, n], 26, 26);
    }
}
// @lc code=end

