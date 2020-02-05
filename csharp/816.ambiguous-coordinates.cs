/*
 * @lc app=leetcode id=816 lang=csharp
 *
 * [816] Ambiguous Coordinates
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<string> Split(string S) {
        int n = S.Length;
        if (n == 1) {
            return new string[] { S };
        }
        if (S[0] == '0') {
            if (S[n - 1] != '0') {
                return new string[] { $"0.{S.Substring(1)}" };
            }
            return Enumerable.Empty<string>();
        }
        if (S[n - 1] == '0') {
            return new string[] { S };
        }
        return Enumerable
            .Range(1, n - 1)
            .Select(i => $"{S.Substring(0, i)}.{S.Substring(i)}")
            .Append(S)
            .ToArray();
    }

    public IList<string> AmbiguousCoordinates(string S) {
        int n = S.Length;
        return Enumerable
            .Range(1, n - 3)
            .Select(i => (First: Split(S.Substring(1, i)), Second: Split(S.Substring(i + 1, n - i - 2))))
            .SelectMany(tuple => tuple.First.SelectMany(f => tuple.Second.Select(s => $"({f}, {s})")))
            .ToList();
    }
}
// @lc code=end

