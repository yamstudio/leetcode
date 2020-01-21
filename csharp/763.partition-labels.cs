/*
 * @lc app=leetcode id=763 lang=csharp
 *
 * [763] Partition Labels
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<int> PartitionLabels(string S) {
        int n = S.Length, start = 0, end = 0;
        var map = new Dictionary<char, int>();
        var ret = new List<int>();
        for (int i = 0; i < n; ++i) {
            map[S[i]] = i;
        }
        for (int i = 0; i < n; ++i) {
            end = Math.Max(map[S[i]], end);
            if (i == end) {
                ret.Add(end - start + 1);
                start = end + 1;
                end = start;
            }
        }
        return ret;
    }
}
// @lc code=end

