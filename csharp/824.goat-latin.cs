/*
 * @lc app=leetcode id=824 lang=csharp
 *
 * [824] Goat Latin
 */

using System.Collections.Generic;
using System.Text;

// @lc code=start
public class Solution {

    private static readonly bool[] Vowels = new bool[] {
        true, false, false, false, true,
        false, false, false, true, false,
        false, false, false, false, true,
        false, false, false, false, false,
        true, false, false, false, false,
        false
    };

    private static IEnumerable<string> GetNext(string S) {
        var sb = new StringBuilder();
        sb.Append("maa");
        foreach (string word in S.Split(' ')) {
            char c = word[0];
            if (Vowels[(c >= 'a' && c <= 'z') ? (int)c - (int)'a' : (int)c -(int)'A']) {
                yield return $"{word}{sb.ToString()}";
            } else {
                yield return $"{word.Substring(1)}{c}{sb.ToString()}";
            }
            
            sb.Append('a');
        }
    }

    public string ToGoatLatin(string S) {
        return string.Join(' ', GetNext(S));
    }
}
// @lc code=end

