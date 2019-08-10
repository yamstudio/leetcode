/*
 * @lc app=leetcode id=213 lang=csharp
 *
 * [213] House Robber II
 */
public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if (n == 0) {
            return 0;
        }
        int prev = 0, ret = nums[0], curr = 0;
        for (int i = 0; i < n - 1; ++i) {
            int rob = prev + nums[i];
            ret = Math.Max(ret, rob);
            prev = Math.Max(prev, curr);
            curr = rob;
        }
        prev = 0;
        curr = 0;
        for (int i = 1; i < n; ++i) {
            int rob = prev + nums[i];
            ret = Math.Max(ret, rob);
            prev = Math.Max(prev, curr);
            curr = rob;
        }
        return ret;
    }
}

