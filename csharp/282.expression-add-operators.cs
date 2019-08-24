/*
 * @lc app=leetcode id=282 lang=csharp
 *
 * [282] Expression Add Operators
 */

using System.Collections.Generic;

public class Solution {

    private static void AddOperatorsRecurse(string num, long target, long curr, long delta, string str, IList<string> ret) {
        if (num.Length == 0) {
            if (curr == target) {
                ret.Add(str);
            }
            return;
        }
        for (int i = 1; i <= num.Length; ++i) {
            string head = num.Substring(0, i), tail = num.Substring(i);
            if (i > 1 && head[0] == '0') {
                continue;
            }
            long n = long.Parse(head);
            if (str.Length > 0) {
                AddOperatorsRecurse(tail, target, curr + n, n, $"{str}+{head}", ret);
                AddOperatorsRecurse(tail, target, curr - n, -n, $"{str}-{head}", ret);
                AddOperatorsRecurse(tail, target, (curr - delta) + delta * n, delta * n, $"{str}*{head}", ret);
            } else {
                AddOperatorsRecurse(tail, target, n, n, head, ret);
            }
        }
    }


    public IList<string> AddOperators(string num, int target) {
        IList<string> ret = new List<string>();
        AddOperatorsRecurse(num, (long) target, 0, 0, "", ret);
        return ret;
    }
}

