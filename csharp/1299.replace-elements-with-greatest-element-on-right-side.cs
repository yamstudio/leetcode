/*
 * @lc app=leetcode id=1299 lang=csharp
 *
 * [1299] Replace Elements with Greatest Element on Right Side
 */

using System;

// @lc code=start
public class Solution {
    public int[] ReplaceElements(int[] arr) {
        int n = arr.Length;
        int[] ret = new int[n];
        ret[n - 1] = -1;
        for (int i = n - 2; i >= 0; --i) {
            ret[i] = Math.Max(ret[i + 1], arr[i + 1]);
        }
        return ret;
    }
}
// @lc code=end

