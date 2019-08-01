/*
 * @lc app=leetcode id=153 lang=csharp
 *
 * [153] Find Minimum in Rotated Sorted Array
 */
public class Solution {
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] > nums[right]) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return nums[left];
    }
}

