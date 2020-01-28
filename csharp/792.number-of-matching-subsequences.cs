/*
 * @lc app=leetcode id=792 lang=csharp
 *
 * [792] Number of Matching Subsequences
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int NumMatchingSubseq(string S, string[] words) {
        int ret = 0, n = S.Length;
        var map = new Dictionary<string, bool>();
        foreach (var word in words) {
            if (map.TryGetValue(word, out bool val)) {
                if (val) {
                    ++ret;
                }
                continue;
            }
            int m = word.Length, i = 0, j = 0;
            while (i < n && j < m) {
                if (word[j] == S[i]) {
                    ++j;
                }
                ++i;
            }
            if (j == m) {
                ++ret;
                map[word] = true;
            } else {
                map[word] = false;
            }
        }
        return ret;
    }
}
// @lc code=end

