/*
 * @lc app=leetcode id=33 lang=csharp
 *
 * [33] Search in Rotated Sorted Array
 */
public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left <= right - 2) {
            int mid = (left + right) / 2;
            if (target >= nums[mid]) {
                if (nums[left] > nums[mid] && nums[left] <= target) {
                    right = mid;
                } else {
                    left = mid;
                }
            } else {
                if (nums[right] < nums[mid] && nums[right] >= target) {
                    left = mid;
                } else {
                    right = mid;
                }
            }
        }
        while (left <= right) {
            if (nums[left] == target) {
                return left;
            }
            ++left;
        }
        return -1;
    }
}

