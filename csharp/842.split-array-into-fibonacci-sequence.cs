/*
 * @lc app=leetcode id=842 lang=csharp
 *
 * [842] Split Array into Fibonacci Sequence
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static bool SplitIntoFibonacciRecurse(string S, int start, IList<int> ret) {
        int len = S.Length, count = ret.Count;
        if (start == len) {
            return true;
        }

        var target = (long)ret[count - 1] + (long)ret[count - 2];

        if (target > int.MaxValue) {
            return false;
        }
        var targetString = target.ToString();
        if (len - start < targetString.Length || S.Substring(start, targetString.Length) != targetString) {
            return false;
        }
        ret.Add((int)target);
        var okay = SplitIntoFibonacciRecurse(S, start + targetString.Length, ret);
        if (!okay) {
            ret.RemoveAt(count);
        }
        return okay;
    }

    public IList<int> SplitIntoFibonacci(string S) {
        var ret = new List<int>();
        int len = S.Length;
        for (int i = 0; i < len; ++i) {
            long v1 = long.Parse(S.Substring(0, i + 1));
            if (v1 > int.MaxValue) {
                break;
            }
            ret.Add((int)v1);
            for (int j = i + 1; j < len - 1; ++j) {
                long v2 = long.Parse(S.Substring(i + 1, j - i));
                if (v2 > int.MaxValue) {
                    break;
                }
                ret.Add((int)v2);
                if (SplitIntoFibonacciRecurse(S, j + 1, ret)) {
                    return ret;
                }
                ret.RemoveAt(1);
                if (v2 == 0) {
                    break;
                }
            }
            ret.RemoveAt(0);
            if (v1 == 0) {
                break;
            }
        }
        return ret;
    }
}
// @lc code=end

