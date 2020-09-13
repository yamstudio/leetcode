/*
 * @lc app=leetcode id=1187 lang=csharp
 *
 * [1187] Make Array Strictly Increasing
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MakeArrayIncreasing(int[] arr1, int[] arr2) {
        arr2 = arr2.Distinct().OrderBy(x => x).ToArray();
        int m = arr1.Length, n = arr2.Length, noSwap = 0;
        int[] swap = Enumerable.Repeat(1, n).ToArray();
        for (int i = 1; i < m; ++i) {
            int newNoSwap = arr1[i] > arr1[i - 1] ? noSwap : 100000;
            int[] newSwap = Enumerable.Repeat(100000, n).ToArray();
            for (int j = 0; j < n; ++j) {
                if (arr1[i] > arr2[j]) {
                    newNoSwap = Math.Min(newNoSwap, swap[j]);
                }
                if (j > 0) {
                    newSwap[j] = Math.Min(newSwap[j], 1 + swap[j - 1]);
                }
                if (arr2[j] > arr1[i - 1]) {
                    newSwap[j] = Math.Min(newSwap[j], noSwap + 1);
                }
            }
            noSwap = newNoSwap;
            swap = newSwap;
        }
        int ret = Math.Min(noSwap, swap.Min());
        return ret >= 100000 ? -1 : ret;
    }
}
// @lc code=end

