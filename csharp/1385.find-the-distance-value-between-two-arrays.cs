/*
 * @lc app=leetcode id=1385 lang=csharp
 *
 * [1385] Find the Distance Value Between Two Arrays
 */

using System;

// @lc code=start
public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        int m = arr1.Length, n = arr2.Length, i = 0, j = 0, ret = 0;
        Array.Sort(arr1);
        Array.Sort(arr2);
        while (i < m && j < n) {
            int a = arr1[i], b = arr2[j];
            if (b < a - d) {
                ++j;
            } else if (b <= a + d) {
                ++i;
            } else {
                ++i;
                ++ret;
            }
        }
        return ret + m - i;
    }
}
// @lc code=end

