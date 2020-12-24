/*
 * @lc app=leetcode id=1608 lang=csharp
 *
 * [1608] Special Array With X Elements Greater Than or Equal X
 */

using System;

// @lc code=start
public class Solution {
    public int SpecialArray(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        for (int i = 0; i < n;) {
            int p = i == 0 ? -1 : nums[i - 1];
            if (n - i > p && n - i <= nums[i]) {
                return n - i;
            }
            int ni= i + 1;
            while (ni < n && nums[ni] == nums[i]) {
                ++ni;
            }
            i = ni;
        }
        return -1;
    }
}
// @lc code=end

