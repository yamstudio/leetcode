/*
 * @lc app=leetcode id=1598 lang=csharp
 *
 * [1598] Crawler Log Folder
 */

// @lc code=start
public class Solution {
    public int MinOperations(string[] logs) {
        int d = 0;
        foreach (var log in logs) {
            if (log == "./") {
                continue;
            }
            if (log == "../") {
                if (d > 0) {
                    --d;
                }
                continue;
            }
            ++d;
        }
        return d;
    }
}
// @lc code=end

