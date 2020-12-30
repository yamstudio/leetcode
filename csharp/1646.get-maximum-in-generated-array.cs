/*
 * @lc app=leetcode id=1646 lang=csharp
 *
 * [1646] Get Maximum in Generated Array
 */

using System;

// @lc code=start
public class Solution {
    public int GetMaximumGenerated(int n) {
        if (n == 0) {
            return 0;
        }
        var arr = new int[n + 1];
        int ret = 1;
        arr[0] = 0;
        arr[1] = 1;
        for (int i = 2; i <= n; ++i) {
            if (i % 2 == 0) {
                arr[i] = arr[i / 2];
            } else {
                arr[i] = arr[i / 2] + arr[i / 2 + 1];
            }
            ret = Math.Max(ret, arr[i]);
        }
        return ret;
    }
}
// @lc code=end

