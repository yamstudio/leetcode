/*
 * @lc app=leetcode id=1537 lang=csharp
 *
 * [1537] Get the Maximum Score
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxSum(int[] nums1, int[] nums2) {
        long acc1 = 0, acc2 = 0, ret = 0;
        int n1 = nums1.Length, n2 = nums2.Length, i1 = 0, i2 = 0;
        while (i1 < n1 || i2 < n2) {
            if (i1 == n1) {
                acc2 += nums2[i2++];
                continue;
            }
            if (i2 == n2) {
                acc1 += nums1[i1++];
                continue;
            }
            int c1 = nums1[i1], c2 = nums2[i2];
            if (c1 < c2) {
                acc1 += c1;
                ++i1;
            } else if (c1 > c2) {
                acc2 += c2;
                ++i2;
            } else {
                ret += Math.Max(acc1, acc2);
                acc1 = c1;
                acc2 = c2;
                ++i1;
                ++i2;
            }
        }
        return (int)((ret + Math.Max(acc1, acc2)) % 1000000007);
    }
}
// @lc code=end

