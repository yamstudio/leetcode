/*
 * @lc app=leetcode id=1366 lang=csharp
 *
 * [1366] Rank Teams by Votes
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string RankTeams(string[] votes) {
        int n = votes[0].Length;
        int[,] count = new int[26, 26];
        foreach (var vote in votes) {
            for (int i = 0; i < n; ++i) {
                ++count[(int)vote[i] - (int)'A', i];
            }
        }
        return new string(Enumerable
            .Range(0, 26)
            .OrderByDescending(i => count[i, 0])
            .ThenByDescending(i => count[i, 1])
            .ThenByDescending(i => count[i, 2])
            .ThenByDescending(i => count[i, 3])
            .ThenByDescending(i => count[i, 4])
            .ThenByDescending(i => count[i, 5])
            .ThenByDescending(i => count[i, 6])
            .ThenByDescending(i => count[i, 7])
            .ThenByDescending(i => count[i, 8])
            .ThenByDescending(i => count[i, 9])
            .ThenByDescending(i => count[i, 10])
            .ThenByDescending(i => count[i, 11])
            .ThenByDescending(i => count[i, 12])
            .ThenByDescending(i => count[i, 13])
            .ThenByDescending(i => count[i, 14])
            .ThenByDescending(i => count[i, 15])
            .ThenByDescending(i => count[i, 16])
            .ThenByDescending(i => count[i, 17])
            .ThenByDescending(i => count[i, 18])
            .ThenByDescending(i => count[i, 19])
            .ThenByDescending(i => count[i, 20])
            .ThenByDescending(i => count[i, 21])
            .ThenByDescending(i => count[i, 22])
            .ThenByDescending(i => count[i, 23])
            .ThenByDescending(i => count[i, 24])
            .ThenByDescending(i => count[i, 25])
            .ThenBy(i => i)
            .Take(n)
            .Select(i => (char)(i + (int)'A'))
            .ToArray()
        );
    }
}
// @lc code=end

