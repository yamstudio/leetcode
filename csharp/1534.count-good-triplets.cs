/*
 * @lc app=leetcode id=1534 lang=csharp
 *
 * [1534] Count Good Triplets
 */

using System;

// @lc code=start
public class Solution {
    public int CountGoodTriplets(int[] arr, int a, int b, int c) {
        int n = arr.Length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int first = arr[i];
            for (int j = i + 1; j < n; ++j) {
                int second = arr[j];
                if (Math.Abs(first - second) > a) {
                    continue;
                }
                for (int k = j + 1; k < n; ++k) {
                    int third = arr[k];
                    if (Math.Abs(second - third) > b || Math.Abs(first - third) > c) {
                        continue;
                    }
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

