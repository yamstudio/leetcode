/*
 * @lc app=leetcode id=753 lang=csharp
 *
 * [753] Cracking the Safe
 */

using System.Collections.Generic;
using System.Linq;
using System;

// @lc code=start
public class Solution {
    public string CrackSafe(int n, int k) {
        var curr = Enumerable.Repeat('0', n).ToList();
        var visited = new HashSet<string>();
        visited.Add(new string(curr.ToArray()));
        for (int i = (int) Math.Pow((double) k, (double) n); i > 0; --i) {
            var sub = curr.GetRange(curr.Count - n + 1, n - 1).Append('0').ToArray();
            for (int j = k - 1; j >= 0; --j) {
                sub[n - 1] = (char) (j + (int) '0');
                var next = new string(sub);
                if (!visited.Contains(next)) {
                    curr.Add((char) (j + (int) '0'));
                    visited.Add(next);
                    break;
                }
            }
        }
        return new string(curr.ToArray());
    }
}
// @lc code=end

