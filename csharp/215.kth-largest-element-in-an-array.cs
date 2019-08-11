/*
 * @lc app=leetcode id=215 lang=csharp
 *
 * [215] Kth Largest Element in an Array
 */
public class Solution {

    private int QuickSort(int[] nums, int left, int right) {
        int pivot = nums[left], l = left + 1, r = right;
        while (l <= r) {
            if (nums[l] < pivot && nums[r] > pivot) {
                int tmp = nums[l];
                nums[l++] = nums[r];
                nums[r--] = tmp;
            }
            if (nums[l] >= pivot) {
                ++l;
            } 
            if (nums[r] <= pivot) {
                --r;
            }
        }
        nums[left] = nums[r];
        nums[r] = pivot;
        return r;
    }

    public int FindKthLargest(int[] nums, int k) {
        int left = 0, right = nums.Length - 1;
        while (true) {
            int m = QuickSort(nums, left, right);
            if (m == k - 1) {
                return nums[m];
            }
            if (m > k - 1) {
                right = m - 1;
            } else {
                left = m + 1;
            }
        }
    }
}

