/*
 * @lc app=leetcode id=75 lang=csharp
 *
 * [75] Sort Colors
 */
public class Solution {
    public void SortColors(int[] nums) {
        int left = 0, right = nums.Length - 1, curr = 0;
        while (curr <= right) {
            if (nums[curr] == 1) {
                ++curr;
            } else if (nums[curr] == 0) {
                if (curr > left) {
                    nums[left] = 0;
                    nums[curr] = 1;
                }
                ++left;
                ++curr;
            } else {
                nums[curr] = nums[right];
                nums[right--] = 2;
            }
        }
    }
}

