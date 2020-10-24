/*
 * @lc app=leetcode id=1370 lang=csharp
 *
 * [1370] Increasing Decreasing String
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<char> GetChar(int[] count) {
        while (true) {
            for (int i = 0; i < 26; ++i) {
                if (count[i] > 0) {
                    --count[i];
                    yield return (char)(i + (int)'a');
                }
            }
            for (int i = 25; i >= 0; --i) {
                if (count[i] > 0) {
                    --count[i];
                    yield return (char)(i + (int)'a');
                }
            }
        }
    }

    public string SortString(string s) {
        int n = s.Length;
        int[] count = new int[26];
        foreach (char c in s) {
            ++count[(int)c - (int)'a'];
        }
        return new string(GetChar(count).Take(n).ToArray());
    }
}
// @lc code=end

