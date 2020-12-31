/*
 * @lc app=leetcode id=1649 lang=csharp
 *
 * [1649] Create Sorted Array through Instructions
 */

using System;

// @lc code=start
public class Solution {

    private static void Set(int[] fenwick, int i) {
        while (i <= 100000) {
            ++fenwick[i];
            i += i & (-i);
        }
    }

    private static int Get(int[] fenwick, int i) {
        int ret = 0;
        while (i > 0) {
            ret += fenwick[i];
            i -= i & (-i);
        }
        return ret;
    }

    public int CreateSortedArray(int[] instructions) {
        var fenwick = new int[100001];
        int ret = 0, n = instructions.Length;
        for (int i = 0; i < n; ++i) {
            int x = instructions[i];
            ret = (ret + Math.Min(Get(fenwick, x - 1), i - Get(fenwick, x))) % 1000000007;
            Set(fenwick, x);
        }
        return ret;
    }
}
// @lc code=end

