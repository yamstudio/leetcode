/*
 * @lc app=leetcode id=665 lang=csharp
 *
 * [665] Non-decreasing Array
 */

// @lc code=start
public class Solution {
    public bool CheckPossibility(int[] nums) {
        bool flag = false;
        int n = nums.Length;
        for (int i = 1; i < n; ++i) {
            int num = nums[i];
            if (num < nums[i - 1]) {
                if (flag) {
                    return false;
                }
                if (i == 1 || num >= nums[i - 2]) {
                    nums[i - 1] = num;
                } else {
                    nums[i] = nums[i - 1];
                }
                flag = true;
            }
        }
        return true;
    }
}
// @lc code=end

