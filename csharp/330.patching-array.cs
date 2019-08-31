/*
 * @lc app=leetcode id=330 lang=csharp
 *
 * [330] Patching Array
 */
public class Solution {
    public int MinPatches(int[] nums, int n) {
        long curr = 1;
        int i = 0, ret = 0;
        while (curr <= n) {
            if (i < nums.Length && nums[i] <= curr) {
                curr += nums[i++];
            } else {
                ++ret;
                curr *= 2;
            }
        }
        return ret;
    }
}

