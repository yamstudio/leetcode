/*
 * @lc app=leetcode id=1178 lang=csharp
 *
 * [1178] Number of Valid Words for Each Puzzle
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles) {
        int n = puzzles.Length;
        var ret = new List<int>(n);
        var count = new Dictionary<int, int>();
        foreach (var word in words) {
            int key = 0;
            foreach (var c in word) {
                key |= (1 << ((int)c - (int)'a'));
            }
            if (count.TryGetValue(key, out var t)) {
                count[key] = t + 1;
            } else {
                count[key] = 1;
            }
        }
        foreach (var puzzle in puzzles) {
            int m = puzzle.Length, r = 0;
            for (int i = (1 << (m - 1)) - 1; i >= 0; --i) {
                int key = 1 << ((int)puzzle[0] - (int)'a');
                for (int j = 1; j < m; ++j) {
                    if (((1 << (j - 1)) & i) != 0) {
                        key |= 1 << ((int)puzzle[j] - (int)'a');
                    }
                }
                if (count.TryGetValue(key, out int t)) {
                    r += t;
                }
            }
            ret.Add(r);
        }
        return ret;
    }
}
// @lc code=end

