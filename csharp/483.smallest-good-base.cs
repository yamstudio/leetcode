/*
 * @lc app=leetcode id=483 lang=csharp
 *
 * [483] Smallest Good Base
 */

using System;

// @lc code=start
public class Solution {
    public string SmallestGoodBase(string n) {
        long num = long.Parse(n);
        for (long length = (long) Math.Log(num + 1, 2); length >= 2; --length) {
            long left = 2, right = 1 + (long) Math.Pow(num, 1 / (double) (length - 1));
            while (left < right) {
                long sum = 0, mid = left + (right - left) / 2;
                for (long i = 0; i < length; ++i) {
                    sum = 1 + sum * mid;
                }
                if (sum == num) {
                    return mid.ToString();
                } else if (sum < num) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }
        return (num - 1).ToString();
    }
}
// @lc code=end

