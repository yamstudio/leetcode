/*
 * @lc app=leetcode id=954 lang=csharp
 *
 * [954] Array of Doubled Pairs
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static bool CanReorder(List<int> nums) {
        int n = nums.Count;
        if (n % 2 == 1) {
            return false;
        }
        nums.Sort();
        var map = nums
            .Select((int num, int index) => (Num: num, Index: index))
            .GroupBy(tuple => tuple.Num, (int num, IEnumerable<(int Num, int Index)> tuples) => (Num: num, Indices: tuples.Select(tuple => tuple.Index).ToList()))
            .ToDictionary(tuple => tuple.Num, tuple => tuple.Indices);
        for (int i = 0; i < n; ++i) {
            int curr = nums[i];
            var list = map[curr];
            if (list.Count == 0 || list[0] != i) {
                continue;
            }
            list.RemoveAt(0);
            if (!map.TryGetValue(2 * curr, out var next) || next.Count == 0) {
                return false;
            }
            next.RemoveAt(0);
        }
        return true;
    }

    public bool CanReorderDoubled(int[] A) {
        int zc = 0;
        List<int> l = new List<int>(), r = new List<int>();
        foreach (int x in A) {
            if (x < 0) {
                l.Add(-x);
            } else if (x == 0) {
                ++zc;
            } else {
                r.Add(x);
            }
        }
        return zc % 2 == 0 && CanReorder(l) && CanReorder(r);
    }
}
// @lc code=end

