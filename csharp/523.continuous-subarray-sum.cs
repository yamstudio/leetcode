/*
 * @lc app=leetcode id=523 lang=csharp
 *
 * [523] Continuous Subarray Sum
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        ISet<int> set = new HashSet<int>();
        int curr = 0, prev = 0;
        foreach (int num in nums) {
            curr += num;
            if (k != 0) {
                curr %= k;
            }
            if (set.Contains(curr)) {
                return true;
            }
            set.Add(prev);
            prev = curr;
        }
        return false;
    }
}
// @lc code=end

