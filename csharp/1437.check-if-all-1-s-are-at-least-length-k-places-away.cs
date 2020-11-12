/*
 * @lc app=leetcode id=1437 lang=csharp
 *
 * [1437] Check If All 1's Are at Least Length K Places Away
 */

// @lc code=start
public class Solution {
    public bool KLengthApart(int[] nums, int k) {
        int n = nums.Length, i = 0;
        while (i < n && nums[i] == 0) {
            ++i;
        }
        while (i < n) {
            int j = i + 1;
            while (j < n && nums[j] == 0) {
                ++j;
            }
            if (j < n && j - i <= k) {
                return false;
            }
            i = j;
        }
        return true;
    }
}
// @lc code=end

