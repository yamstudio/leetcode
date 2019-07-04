/*
 * @lc app=leetcode id=31 lang=csharp
 *
 * [31] Next Permutation
 */
public class Solution {
    public void NextPermutation(int[] nums) {
        if (nums.Length <= 1) {
            return;
        }
        int left = nums.Length - 2;
        while (left >= 0 && nums[left] >= nums[left + 1]) {
            --left;
        }
        if (left >= 0) {
            int right = nums.Length - 1;
            while (nums[right] <= nums[left]) {
                --right;
            }
            int tmp = nums[right];
            nums[right] = nums[left];
            nums[left] = tmp;
        }
        ++left;
        int end = nums.Length - 1;
        while (left < end) {
            int tmp = nums[end];
            nums[end--] = nums[left];
            nums[left++] = tmp;
        }
    }
}

