/*
 * @lc app=leetcode id=324 lang=csharp
 *
 * [324] Wiggle Sort II
 */

using System;

public class Solution {
    public void WiggleSort(int[] nums) {
        int n = nums.Length, g = n, l = (n + 1) / 2;
        int[] sorted = new int[n];
        Array.Copy(nums, sorted, n);
        Array.Sort(sorted);
        for (int i = 0; i < n; ++i) {
            if (i % 2 == 0) {
                nums[i] = sorted[--l];
            } else {
                nums[i] = sorted[--g];
            }
        }
    }
}

