/*
 * @lc app=leetcode id=1239 lang=csharp
 *
 * [1239] Maximum Length of a Concatenated String with Unique Characters
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int MaxLengthRecurse(IList<int> arr, int start, int curr) {
        int ret = 0;
        for (int i = start; i < arr.Count; ++i) {
            if ((curr & arr[i]) == 0) {
                ret = Math.Max(ret, MaxLengthRecurse(arr, i + 1, curr | arr[i]));
            }
        }
        if (ret == 0) {
            while (curr != 0) {
                if ((curr & 1) == 1) {
                    ++ret;
                }
                curr >>= 1;
            }
        }
        return ret;
    }

    public int MaxLength(IList<string> arr) {
        var all = new List<int>();
        foreach (var curr in arr) {
            int acc = 0;
            bool flag = false;
            foreach (var c in curr) {
                int d = 1 << ((int)c - (int)'a');
                if ((d & acc) != 0) {
                    flag = true;
                    break;
                }
                acc |= d;
            }
            if (!flag) {
                all.Add(acc);
            }
        }
        return MaxLengthRecurse(all, 0, 0);
    }
}
// @lc code=end

