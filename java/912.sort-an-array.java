/*
 * @lc app=leetcode id=912 lang=java
 *
 * [912] Sort an Array
 */

// @lc code=start
class Solution {

    private static int partition(int[] nums, int l, int r) {
        int p = nums[r], ret = l;
        for (int i = l; i < r; ++i) {
            int t = nums[i];
            if (t < p) {
                nums[i] = nums[ret];
                nums[ret++] = t;
            }
        }
        nums[r] = nums[ret];
        nums[ret] = p;
        return ret;
    }

    private void sort(int[] nums, int l, int r) {
        if (l >= r) {
            return;
        }
        int m = partition(nums, l, r);
        sort(nums, l, m - 1);
        sort(nums, m + 1, r);
    }

    public int[] sortArray(int[] nums) {
        sort(nums, 0, nums.length - 1);
        return nums;
    }
}
// @lc code=end

