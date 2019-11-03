/*
 * @lc app=leetcode id=621 lang=csharp
 *
 * [621] Task Scheduler
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char t in tasks) {
            int x = (int) t - (int) 'A';
            ++count[x];
        }
        SortedSet<(int, int)> sorted = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2.CompareTo(b.Item2) : a.Item1.CompareTo(b.Item1)));
        for (int i = 0; i < 26; ++i) {
            if (count[i] > 0) {
                sorted.Add((count[i], i));
            }
        }
        IList<(int, int)> tmp = new List<(int, int)>(n + 1);
        int ret = 0;
        while (sorted.Count > 0) {
            int t = sorted.Count;
            for (int i = 0; i <= n && sorted.Count > 0; ++i) {
                var max = sorted.Max;
                sorted.Remove(max);
                if (max.Item1 > 1) {
                    tmp.Add((max.Item1 - 1, max.Item2));
                }
            }
            foreach (var pair in tmp) {
                sorted.Add(pair);
            }
            if (sorted.Count > 0) {
                ret += n + 1;
            } else {
                ret += t;
            }
            tmp.Clear();
        }
        return ret;
    }
}
// @lc code=end

