/*
 * @lc app=leetcode id=1482 lang=csharp
 *
 * [1482] Minimum Number of Days to Make m Bouquets
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        if (bloomDay.Length < m * k) {
            return -1;
        }
        var days = bloomDay.Distinct().OrderBy(x => x).ToArray();
        int t = days.Length, l = 0, r = t;
        while (l < r) {
            int mi = (l + r) / 2, mb = days[mi], acc = 0, prev = 0;
            foreach (int d in bloomDay) {
                if (d <= mb) {
                    ++prev;
                    if (prev == k) {
                        prev = 0;
                        if (++acc >= m) {
                            break;
                        }
                    }
                } else {
                    prev = 0;
                }
            }
            if (acc >= m) {
                r = mi;
            } else {
                l = mi + 1;
            }
        }
        return days[l];
    }
}
// @lc code=end

