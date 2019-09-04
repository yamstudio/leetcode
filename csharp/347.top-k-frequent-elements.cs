/*
 * @lc app=leetcode id=347 lang=csharp
 *
 * [347] Top K Frequent Elements
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> TopKFrequent(int[] nums, int k) {
        IDictionary<int, int> count = new Dictionary<int, int>();
        SortedSet<(int, int)> sorted = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((t1, t2) => t1.Item2 == t2.Item2 ? t1.Item1.CompareTo(t2.Item1) : t1.Item2.CompareTo(t2.Item2)));
        IList<int> ret = new List<int>(k);
        foreach (int num in nums) {
            count[num] = 1 + (count.ContainsKey(num) ? count[num] : 0);
        }
        foreach (var entry in count) {
            sorted.Add((entry.Key, entry.Value));
        }
        while (k-- > 0) {
            var entry = sorted.Max;
            ret.Add(entry.Item1);
            sorted.Remove(entry);
        }
        return ret;
    }
}

