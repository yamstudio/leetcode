/*
 * @lc app=leetcode id=875 lang=csharp
 *
 * [875] Koko Eating Bananas
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinEatingSpeed(int[] piles, int H) {
        long sum = 0, left, right = 0;
        foreach (var p in piles) {
            sum += (long)p;
            right = Math.Max((long)p, right);
        }
        if (sum <= (long)H) {
            return 1;
        }
        left = sum / (long)H;
        while (left < right) {
            long mid = left + (right - left) / 2;
            if (piles.Select(p => ((long)p + mid - 1) / mid).Sum() <= (long)H) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return (int)left;
    }
}
// @lc code=end

