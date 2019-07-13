/*
 * @lc app=leetcode id=80 lang=csharp
 *
 * [80] Remove Duplicates from Sorted Array II
 */
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        int left = 0, prev = nums[0], count = 0;
        for (int i = 0; i < nums.Length; ++i) {
            int n = nums[i];
            if (n != prev) {
                prev = n;
                count = 0;
            }
            if (count < 2) {
                nums[left++] = prev;
                ++count;
            }
        }
        return left;
    }
}

