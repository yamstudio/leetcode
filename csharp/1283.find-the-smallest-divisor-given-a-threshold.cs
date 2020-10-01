/*
 * @lc app=leetcode id=1283 lang=csharp
 *
 * [1283] Find the Smallest Divisor Given a Threshold
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int SmallestDivisor(int[] nums, int threshold) {
        int l = 1, r = nums.Max(), n = nums.Length;
        while (l < r) {
            int acc = 0, m = (l + r) / 2;
            for (int i = 0; i < n && acc <= threshold; ++i) {
                acc += (nums[i] + m - 1) / m;
            }
            if (acc > threshold) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return l;
    }
}
// @lc code=end

