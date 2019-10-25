/*
 * @lc app=leetcode id=560 lang=csharp
 *
 * [560] Subarray Sum Equals K
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        IDictionary<int, int> count = new Dictionary<int, int>();
        int ret = 0, sum = 0;
        count[0] = 1;
        foreach (int num in nums) {
            sum += num;
            int c = 0;
            count.TryGetValue(sum - k, out c);
            ret += c;
            count.TryGetValue(sum, out c);
            count[sum] = 1 + c;
        }
        return ret;
    }
}
// @lc code=end

