/*
 * @lc app=leetcode id=34 lang=csharp
 *
 * [34] Find First and Last Position of Element in Sorted Array
 */
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        int[] ret = new int[] { -1, -1 };
        if (nums.Length == 0) {
            return ret;
        }
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] >= target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        if (nums[left] == target) {
            ret[0] = left;
        }
        left = 0;
        right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (nums[mid] <= target) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        if (nums[left] == target) {
            ret[1] = left;
        }
        return ret;
    }
}

