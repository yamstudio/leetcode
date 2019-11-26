/*
 * @lc app=leetcode id=704 lang=csharp
 *
 * [704] Binary Search
 */

// @lc code=start
public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] < target) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return l < nums.Length && nums[l] == target ? l : -1;
    }
}
// @lc code=end

