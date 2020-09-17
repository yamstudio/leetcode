/*
 * @lc app=leetcode id=1203 lang=csharp
 *
 * [1203] Sort Items by Groups Respecting Dependencies
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static bool SortItemsRecurse(IList<int> sorted, int[] added, HashSet<int>[] deps, int curr) {
        if (added[curr] == 1) {
            return false;
        }
        if (added[curr] == 2) {
            return true;
        }
        added[curr] = 1;
        foreach (var next in deps[curr]) {
            if (!SortItemsRecurse(sorted, added, deps, next)) {
                return false;
            }
        }
        sorted.Add(curr);
        added[curr] = 2;
        return true;
    }

    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems) {
        int t = n + 2 * m;
        var deps = new HashSet<int>[t];
        var added = new int[t];
        var sorted = new List<int>(t);
        for (int i = 0; i < t; ++i) {
            deps[i] = new HashSet<int>();
        }
        for (int i = 0; i < n; ++i) {
            if (group[i] != -1) {
                deps[i].Add(n + m + group[i]);
                deps[n + group[i]].Add(i);
            }
            foreach (var before in beforeItems[i]) {
                if (group[i] != -1 && group[i] == group[before]) {
                    deps[before].Add(i);
                } else {
                    int gi = group[i] == -1 ? i : (n + group[i]);
                    int gb = group[before] == -1 ? before : (n + m + group[before]);
                    deps[gb].Add(gi);
                }
            }
        }
        for (int i = t - 1; i >= 0; --i) {
            if (!SortItemsRecurse(sorted, added, deps, i)) {
                return new int[0];
            }
        }
        return sorted.Where(i => i < n).Reverse().ToArray();
    }
}
// @lc code=end

