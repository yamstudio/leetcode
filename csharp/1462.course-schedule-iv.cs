/*
 * @lc app=leetcode id=1462 lang=csharp
 *
 * [1462] Course Schedule IV
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<bool> CheckIfPrerequisite(int n, int[][] prerequisites, int[][] queries) {
        var connected = new bool[n, n];
        foreach (var p in prerequisites) {
            connected[p[0], p[1]] = true;
        }
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                for (int k = 0; k < n; ++k) {
                    connected[j, k] = connected[j, k] || connected[j, i] && connected[i, k];
                }
            }
        }
        return queries.Select(p => connected[p[0], p[1]]).ToList();
    }
}
// @lc code=end

