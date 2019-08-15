/*
 * @lc app=leetcode id=227 lang=csharp
 *
 * [227] Basic Calculator II
 */

using System.Collections.Generic;

public class Solution {
    public int Calculate(string s) {
        IList<int> nums = new List<int>();
        IList<char> ops = new List<char>();
        int i = 0;
        char c;
        while (i < s.Length) {
            c = s[i];
            if (c == ' ') {
                i++;
                continue;
            } else if (c == '+' || c == '-' || c == '*' || c == '/') {
                i++;
                ops.Add(c);
            } else {
                int val = 0, top = ops.Count - 1;
                while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
                    val = 10 * val + (int) s[i] - (int) '0';
                    ++i;
                }
                if (top < 0 || ops[top] == '+' || ops[top] == '-') {
                    nums.Add(val);
                } else if (ops[top] == '*') {
                    nums[top] *= val;
                    ops.RemoveAt(top);
                } else {
                    nums[top] /= val;
                    ops.RemoveAt(top);
                }
            }
        }
        int ret = nums[0];
        for (i = 0; i < ops.Count; ++i) {
            ret += (ops[i] == '+' ? 1 : -1) * nums[i + 1];
        }
        return ret;
    }
}

