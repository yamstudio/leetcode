/*
 * @lc app=leetcode id=692 lang=csharp
 *
 * [692] Top K Frequent Words
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        SortedSet<(int, string)> sorted = new SortedSet<(int, string)>(Comparer<(int, string)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2.CompareTo(b.Item2) : b.Item1.CompareTo(a.Item1)));
        IDictionary<string, int> count = new Dictionary<string, int>();
        foreach (string word in words) {
            count.TryGetValue(word, out int val);
            count[word] = val + 1;
        }
        foreach (var tuple in count) {
            sorted.Add((tuple.Value, tuple.Key));
            if (sorted.Count > k) {
                sorted.Remove(sorted.Max);
            }
        }
        return (sorted as IEnumerable<(int, string)>).Select(pair => pair.Item2).ToList();
    }
}
// @lc code=end

