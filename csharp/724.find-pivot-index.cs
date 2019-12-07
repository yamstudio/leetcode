/*
 * @lc app=leetcode id=724 lang=csharp
 *
 * [724] Find Pivot Index
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int PivotIndex(int[] nums) {
        int n = nums.Length, sum = nums.Sum(), curr = 0;
        for (int i = 0; i < n; ++i) {
            if (2 * curr == sum - nums[i]) {
                return i;
            }
            curr += nums[i];
        }
        return -1;
    }
}
// @lc code=end

