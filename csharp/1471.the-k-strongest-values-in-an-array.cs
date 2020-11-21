/*
 * @lc app=leetcode id=1471 lang=csharp
 *
 * [1471] The k Strongest Values in an Array
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] GetStrongest(int[] arr, int k) {
        int n = arr.Length, m, l = 0, r = n - 1;
        Array.Sort(arr);
        m = arr[(n - 1) / 2];
        while (k-- > 0) {
            if (arr[r] - m >= m - arr[l]) {
                --r;
            } else {
                ++l;
            }
        }
        return arr.Where((x, i) => i < l || i > r).ToArray();
    }
}
// @lc code=end

