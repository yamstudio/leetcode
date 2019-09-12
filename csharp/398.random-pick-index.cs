/*
 * @lc app=leetcode id=398 lang=csharp
 *
 * [398] Random Pick Index
 */

using System;

public class Solution {

    private int[] Nums;
    private Random Gen;

    public Solution(int[] nums) {
        Nums = nums;
        Gen = new Random();
    }
    
    public int Pick(int target) {
        int ret = -1, count = 0;
        for (int i = 0; i < Nums.Length; ++i) {
            if (Nums[i] != target) {
                continue;
            }
            ++count;
            if (Gen.Next() % count == 0) {
                ret = i;
            }
        }
        return ret;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */

