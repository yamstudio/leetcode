/*
 * @lc app=leetcode id=1383 lang=csharp
 *
 * [1383] Maximum Performance of a Team
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxPerformance(int n, int[] speed, int[] efficiency, int k) {
        var engineers = speed
            .Zip(efficiency, (s, e) => (Speed: s, Efficiency: e))
            .Select((t, i) => (Speed: t.Speed, Efficiency: t.Efficiency, Index: i))
            .OrderByDescending(t => t.Efficiency)
            .ToArray();
        var sorted = new SortedSet<(int Speed, int Efficiency, int Index)>(Comparer<(int Speed, int Efficiency, int Index)>.Create((a, b) => {
            if (a.Speed != b.Speed) {
                return a.Speed.CompareTo(b.Speed);
            }
            if (a.Efficiency != b.Efficiency) {
                return a.Efficiency.CompareTo(b.Efficiency);
            }
            return a.Index.CompareTo(b.Index);
        }));
        long ret = 0, speedSum = 0;
        foreach (var engineer in engineers) {
            speedSum += (long)engineer.Speed;
            sorted.Add(engineer);
            if (sorted.Count > k) {
                var min = sorted.Min;
                speedSum -= (long)min.Speed;
                sorted.Remove(min);
            }
            ret = Math.Max(ret, (long)engineer.Efficiency * speedSum);
        }
        return (int)(ret % 1000000007);
    }
}
// @lc code=end

