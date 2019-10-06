/*
 * @lc app=leetcode id=502 lang=csharp
 *
 * [502] IPO
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital) {
        int n = Profits.Length;
        SortedList<(int, int), int> sorted = new SortedList<(int, int), int>(n, Comparer<(int, int)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2.CompareTo(b.Item2) : a.Item1.CompareTo(b.Item1))), affordable = new SortedList<(int, int), int>(n, Comparer<(int, int)>.Create((a, b) => a.Item2 == b.Item2 ? a.Item1.CompareTo(b.Item1) : b.Item2.CompareTo(a.Item2)));
        for (int i = 0; i < n; ++i) {
            var key = (Capital[i], Profits[i]);
            sorted[key] = sorted.ContainsKey(key) ? (1 + sorted[key]) : 1;
        }
        k = Math.Min(k, n);
        while (k-- > 0) {
            int left = 0, right = sorted.Count;
            var keys = sorted.Keys;
            while (left < right) {
                int mid = (left + right) / 2;
                if (keys[mid].Item1 <= W) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            while (right-- > 0) {
                var key = sorted.Keys[0];
                int count = sorted[key];
                sorted.RemoveAt(0);
                affordable.Add(key, count);
            }
            if (affordable.Count == 0) {
                break;
            }
            var buy = affordable.Keys[0];
            if (affordable[buy] == 1) {
                affordable.RemoveAt(0);
            } else {
                affordable[buy]--;
            }
            W += buy.Item2;
        }
        return W;
    }
}
// @lc code=end

