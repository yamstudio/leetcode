/*
 * @lc app=leetcode id=857 lang=csharp
 *
 * [857] Minimum Cost to Hire K Workers
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public double MincostToHireWorkers(int[] quality, int[] wage, int K) {
        var sorted = new SortedList<int, int>();
        int sum = 0, count = 0;
        double ret = double.MaxValue;
        foreach (var worker in quality.Zip(wage, (q, w) => (Ratio: (double)w / (double)q, Quality: q)).OrderBy(w => w.Ratio).ThenBy(w => w.Quality)) {
            if (sorted.TryGetValue(worker.Quality, out var c)) {
                sorted[worker.Quality] = c + 1;
            } else {
                sorted[worker.Quality] = 1;
            }
            sum += worker.Quality;
            ++count;
            if (count > K) {
                var keys = sorted.Keys;
                var remove = keys[keys.Count - 1];
                c = sorted.Values[keys.Count - 1];
                if (c == 1) {
                    sorted.Remove(remove);
                } else {
                    sorted[remove] = c - 1;
                }
                sum -= remove;
                --count;
            }
            if (count >= K) {
                ret = Math.Min(ret, worker.Ratio * (double)sum);
            }
        }
        return ret;
    }
}
// @lc code=end

