/*
 * @lc app=leetcode id=838 lang=csharp
 *
 * [838] Push Dominoes
 */

using System.Collections.Generic;
using System.Text;
using System.Linq;

// @lc code=start
public class Solution {
    public string PushDominoes(string dominoes) {
        var groups = new List<(char State, int Count)>();
        var sb = new StringBuilder(dominoes.Length);
        char prev = '*';
        int len = 1;
        foreach (var c in Enumerable.Concat(dominoes, "*$")) {
            if (c != prev) {
                groups.Add((State: prev, Count: len));
                len = 1;
            } else {
                ++len;
            }
            prev = c;
        }
        int n = groups.Count;
        for (int i = 1; i < n - 1; ++i) {
            (char state, int count) = groups[i];
            if (state == 'L' || state == 'R') {
                sb.Append(state, count);
                continue;
            }
            bool lr = groups[i - 1].State == 'R', rl = groups[i + 1].State == 'L';
            if (lr) {
                if (rl) {
                    int h = count / 2;
                    sb.Append('R', h);
                    if (count % 2 > 0) {
                        sb.Append('.');
                    }
                    sb.Append('L', h);
                } else {
                    sb.Append('R', count);
                }
            } else {
                sb.Append(rl ? 'L' : '.', count);
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

