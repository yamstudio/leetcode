/*
 * @lc app=leetcode id=327 lang=csharp
 *
 * [327] Count of Range Sum
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int CountRangeSum(int[] nums, int lower, int upper) {
        int n = nums.Length + 1;
        SortedSet<(long, int)> sorted = new SortedSet<(long, int)>(Comparer<(long, int)>.Create((t1, t2) => t1.Item1 != t2.Item1 ? t1.Item1.CompareTo(t2.Item1) : t1.Item2.CompareTo(t2.Item2)));
        sorted.Add((0, 0));
        return nums.Aggregate((0, 0L), (t, num) => {
            long sum = t.Item2 + (long) num;
            int count = sorted.GetViewBetween((sum - (long) upper, 0), (sum - (long) lower, n)).Count + t.Item1;
            sorted.Add((sum, sorted.GetViewBetween((sum, 0), (sum, n)).Count));
            return (count, sum);
        }).Item1;
    }
}

