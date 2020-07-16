/*
 * @lc app=leetcode id=937 lang=csharp
 *
 * [937] Reorder Data in Log Files
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        string max = new string('z', logs.Max(log => log.Length));
        return logs
            .Select((string log, int index) => {
                int i = log.IndexOf(' ');
                if (log[i + 1] >= 'a' && log[i + 1] <= 'z') {
                    return (Log: log, First: log.Substring(0, i), Other: log.Substring(i + 1), Index: index);
                } else {
                    return (Log: log, First: "", Other: max, Index: index);
                }
            })
            .OrderBy(tuple => tuple.Other)
            .ThenBy(tuple => tuple.First)
            .ThenBy(tuple => tuple.Index)
            .Select(tuple => tuple.Log)
            .ToArray();
    }
}
// @lc code=end

