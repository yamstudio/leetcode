/*
 * @lc app=leetcode id=55 lang=csharp
 *
 * [55] Jump Game
 */
public class Solution {
    public bool CanJump(int[] nums) {
        int max = 0;
        for (int i = 0; i <= max; ++i) {
            max = Math.Max(max, i + nums[i]);
            if (max >= nums.Length - 1) {
                return true;
            }
        }
        return false;
    }
}

