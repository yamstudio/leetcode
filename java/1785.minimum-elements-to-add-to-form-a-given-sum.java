/*
 * @lc app=leetcode id=1785 lang=java
 *
 * [1785] Minimum Elements to Add to Form a Given Sum
 */

// @lc code=start
class Solution {
    public int minElements(int[] nums, int limit, int goal) {
        long sum = goal;
        for (int x : nums) {
            sum -= x;
        }
        if (sum < 0) {
            sum = -sum;
        }
        return (int)(sum / limit + (sum % limit == 0 ? 0 : 1));
    }
}
// @lc code=end

