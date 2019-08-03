/*
 * @lc app=leetcode id=162 lang=csharp
 *
 * [162] Find Peak Element
 */
public class Solution {
    public int FindPeakElement(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] < nums[mid + 1]) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return right;
    }
}

