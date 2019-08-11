/*
 * @lc app=leetcode id=218 lang=csharp
 *
 * [218] The Skyline Problem
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var ret = new List<IList<int>>();
        var sorted = new SortedList<int, int>(Comparer<int>.Create((a, b) => b - a));
        var bldgs = new List<(int, int)>(2 * buildings.Length);
        int curr, prev = 0;
        foreach (int[] bldg in buildings) {
            bldgs.Add((bldg[0], bldg[2]));
            bldgs.Add((bldg[1], -bldg[2]));
        }
        bldgs.Sort(Comparer<(int, int)>.Create((p1, p2) => p1.Item1 == p2.Item1 ? p2.Item2 - p1.Item2 : p1.Item1 - p2.Item1));
        foreach (var p in bldgs) {
            int h = p.Item2;
            if (h > 0) {
                sorted[h] = sorted.ContainsKey(h) ? sorted[h] + 1 : 1;
                curr = sorted.Keys[0];
            } else {
                h = -h;
                if (sorted[h] > 1) {
                    sorted[h]--;
                } else {
                    sorted.Remove(h);
                }
                curr = sorted.Count > 0 ? sorted.Keys[0] : 0;
            }
            if (curr != prev) {
                ret.Add(new List<int>() { p.Item1, curr });
                prev = curr;
            }
        }
        return ret;
    }
}

