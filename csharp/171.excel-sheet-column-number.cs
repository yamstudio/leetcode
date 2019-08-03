/*
 * @lc app=leetcode id=171 lang=csharp
 *
 * [171] Excel Sheet Column Number
 */

using System.Linq;
using System.Text;

public class Solution {
    public int TitleToNumber(string s) {
        return s.Reverse().Aggregate(new int[] {0, 1},
            (ret, c) => new int[] {
                ret[0] + ret[1] * ((int) c - (int) '@'),
                ret[1] * 26
            },
            ret => ret[0]);
    }
}

