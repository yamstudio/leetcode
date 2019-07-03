/*
 * @lc app=leetcode id=26 lang=csharp
 *
 * [26] Remove Duplicates from Sorted Array
 */
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int left = 0;
        for (int i = 0; i < nums.Length; ++i) {
            if (left == 0 || nums[left - 1] != nums[i]) {
                nums[left++] = nums[i];
            }
        }
        return left;
    }
}

