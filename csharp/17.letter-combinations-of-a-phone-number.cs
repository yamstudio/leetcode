/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 */

using System.Collections.Generic;
using System.Text;

public class Solution {

    private static string[] map = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
    public IList<string> LetterCombinations(string digits) {
        IList<string> ret = new List<string>(), curr = new List<string>(), tmp = null;
        StringBuilder sb = new StringBuilder();

        if (digits.Length == 0) {
            return ret;
        } else {
            ret.Add("");
        }
        foreach (char d in digits) {
            curr.Clear();
            foreach (string pre in ret) {
                sb.Append(pre);
                foreach (char c in map[(int) (d - '2')]) {
                    sb.Append(c);
                    curr.Add(sb.ToString());
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Clear();
            }
            tmp = curr;
            curr = ret;
            ret = tmp;
        }

        return ret;
    }
}

