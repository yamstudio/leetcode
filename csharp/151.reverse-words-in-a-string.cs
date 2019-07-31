/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 */

using System.Linq;

public class Solution {
    public string ReverseWords(string s) {
        return string.Join(" ", s.Split(new char[] { ' ' }).Where(w => w.Length > 0).Reverse());
    }
}

