/*
 * @lc app=leetcode id=1283 lang=java
 *
 * [1283] Find the Smallest Divisor Given a Threshold
 */

// @lc code=start
class Solution {
    public int smallestDivisor(int[] nums, int threshold) {
        int l = 1, r = 0;
        for (int num : nums) {
            r = Math.max(num, r);
        }
        while (l < r) {
            int curr = 0, m = (l + r) / 2;
            for (int num : nums) {
                curr += num / m;
                if (num % m != 0) {
                    ++curr;
                }
            }
            if (curr <= threshold) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
}
// @lc code=end

