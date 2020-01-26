/*
 * @lc app=leetcode id=784 lang=csharp
 *
 * [784] Letter Case Permutation
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    private static void LetterCasePermutationRecurse(List<string> ret, char[] str, int index) {
        if (index == str.Length) {
            ret.Add(new string(str));
            return;
        }
        LetterCasePermutationRecurse(ret, str, index + 1);
        char c = str[index];
        if (c >= 'a' && c <= 'z') {
            str[index] = (char) ((int) c + (int) 'A' - (int) 'a');
            LetterCasePermutationRecurse(ret, str, index + 1);
            str[index] = c;
        } else if (c >= 'A' && c <= 'Z') {
            str[index] = (char) ((int) c - (int) 'A' + (int) 'a');
            LetterCasePermutationRecurse(ret, str, index + 1);
            str[index] = c;
        }
    }
    
    public IList<string> LetterCasePermutation(string S) {
        var ret = new List<string>();
        LetterCasePermutationRecurse(ret, S.ToCharArray(), 0);
        return ret;
    }
}
// @lc code=end

