/*
 * @lc app=leetcode id=198 lang=csharp
 *
 * [198] House Robber
 */
public class Solution {
    public int Rob(int[] nums) {
        int prev = 0, ret = 0, curr = 0;
        foreach (int num in nums) {
            int rob = prev + num;
            ret = Math.Max(ret, rob);
            prev = Math.Max(prev, curr);
            curr = rob;
        }
        return ret;
    }
}

