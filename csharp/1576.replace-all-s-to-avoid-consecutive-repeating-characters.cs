/*
 * @lc app=leetcode id=1576 lang=csharp
 *
 * [1576] Replace All ?'s to Avoid Consecutive Repeating Characters
 */

// @lc code=start
public class Solution {
    public string ModifyString(string s) {
        int n = s.Length;
        var ret = s.ToCharArray();
        for (int i = 0; i < n; ++i) {
            if (s[i] != '?') {
                continue;
            }
            int pc = i == 0 ? '*' : ret[i - 1], nc = i == n - 1 ? '*' : ret[i + 1];
            for (char c = 'a'; c <= 'z'; ++c) {
                if (c != pc && c != nc) {
                    ret[i] = c;
                    break;
                }
            }
        }
        return new string(ret);
    }
}
// @lc code=end

