/*
 * @lc app=leetcode id=45 lang=csharp
 *
 * [45] Jump Game II
 */
public class Solution {
    public int Jump(int[] nums) {
        int maxRight = 0, ret = 0, curr = 0;
        while (maxRight < nums.Length - 1) {
            int right = maxRight;
            for (; curr <= right; ++curr) {
                maxRight = Math.Max(curr + nums[curr], maxRight);
            }
            ++ret;
        }
        return ret;
    }
}

