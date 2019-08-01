/*
 * @lc app=leetcode id=152 lang=csharp
 *
 * [152] Maximum Product Subarray
 */
public class Solution {
    public int MaxProduct(int[] nums) {
        int min = 0, max = 0, ret = int.MinValue;
        if (nums.Length == 1) {
            return nums[0];
        }
        foreach (int num in nums) {
            int pos, neg;
            if (num >= 0) {
                pos = max * num;
                neg = min * num;
                max = Math.Max(pos, num);
                min = Math.Min(0, neg);
            } else {
                pos = min * num;
                neg = max * num;
                max = Math.Max(0, pos);
                min = Math.Min(neg, num);
            }
            ret = Math.Max(max, ret);
        }
        return ret;
    }
}

