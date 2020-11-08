/*
 * @lc app=leetcode id=1423 lang=csharp
 *
 * [1423] Maximum Points You Can Obtain from Cards
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        int acc = cardPoints.Take(k).Sum(), ret = acc, n = cardPoints.Length;
        for (int i = 1; i <= k; ++i) {
            acc = acc - cardPoints[k - i] + cardPoints[n - i];
            ret = Math.Max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

