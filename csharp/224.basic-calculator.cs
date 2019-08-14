/*
 * @lc app=leetcode id=224 lang=csharp
 *
 * [224] Basic Calculator
 */

using System;

public class Solution {

    private static Func<string, int, (int, int)> CalculateRecurse = (s, i) => {
        int ret = 0, sign = 1;
        char c;
        while ((c = s[i]) != ')') {
            if (c == '(') {
                var vals = CalculateRecurse(s, i + 1);
                ret += sign * vals.Item1;
                i = vals.Item2 + 1;
            } else if (c == '+') {
                sign = 1;
                ++i;
            } else if (c == '-') {
                sign = -1;
                ++i;
            } else if (c == ' ') {
                ++i;
            } else {
                int val = 0;
                while (c >= '0' && c <= '9') {
                    val = 10 * val + (int) (c - '0');
                    c = s[++i];
                }
                ret += sign * val;
            }
        }
        return (ret, i);
    };

    public int Calculate(string s) {
        return CalculateRecurse($"{s})", 0).Item1;
    }
}

