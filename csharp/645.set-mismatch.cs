/*
 * @lc app=leetcode id=645 lang=csharp
 *
 * [645] Set Mismatch
 */

// @lc code=start
public class Solution {
    public int[] FindErrorNums(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; ++i) {
            while (nums[i] != nums[nums[i] - 1]) {
                int tmp = nums[i];
                nums[i] = nums[tmp - 1];
                nums[tmp - 1] = tmp;
            }
        }
        for (int i = 0; i < n; ++i) {
            if (nums[i] != i + 1) {
                return new int[] { nums[i], i + 1 };
            }
        }
        return null;
    }
}
// @lc code=end

