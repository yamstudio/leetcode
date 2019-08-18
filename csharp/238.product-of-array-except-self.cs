/*
 * @lc app=leetcode id=238 lang=csharp
 *
 * [238] Product of Array Except Self
 */
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length, right = 1;
        int[] ret = new int[n];
        ret[0] = 1;
        for (int i = 1; i < n; ++i) {
            ret[i] = ret[i - 1] * nums[i - 1];
        }
        for (int i = n - 1; i >= 0; --i) {
            ret[i] *= right;
            right *= nums[i];
        }
        return ret;
    }
}

