/*
 * @lc app=leetcode id=912 lang=csharp
 *
 * [912] Sort an Array
 */

// @lc code=start
public class Solution {
    public int[] SortArray(int[] nums) {
        Quicksort(nums, 0, nums.Length - 1);
        return nums;
    }

    private static void Quicksort(int[] nums, int left, int right) {
        if (left >= right) {
            return;
        }
        int p = Partition(nums, left, right);
        Quicksort(nums, left, p - 1);
        Quicksort(nums, p + 1, right);
    }

    private static int Partition(int[] nums, int left, int right) {
        int pivot = nums[right], ret = left;
        for (int i = left; i < right; ++i) {
            if (nums[i] < pivot) {
                int tmp = nums[ret];
                nums[ret] = nums[i];
                nums[i] = tmp;
                ++ret;
            }
        }
        nums[right] = nums[ret];
        nums[ret] = pivot;
        return ret;
    }
}
// @lc code=end

