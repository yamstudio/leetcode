/*
 * @lc app=leetcode id=447 lang=csharp
 *
 * [447] Number of Boomerangs
 */

using System.Collections.Generic;

public class Solution {
    public int NumberOfBoomerangs(int[][] points) {
        var dict = new Dictionary<int, int>();
        int ret = 0;
        foreach (int[] curr in points) {
            int x = curr[0], y = curr[1];
            foreach (int[] point in points) {
                int dx = x - point[0], dy = y - point[1], d = dx * dx + dy * dy;
                dict[d] = 1 + (dict.ContainsKey(d) ? dict[d] : 0);
            }
            foreach (int val in dict.Values) {
                ret += val * (val - 1);
            }
            dict.Clear();
        }
        return ret;
    }
}

