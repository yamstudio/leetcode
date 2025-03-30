/*
 * @lc app=leetcode id=1512 lang=java
 *
 * [1512] Number of Good Pairs
 */

// @lc code=start
class Solution {
    public int numIdenticalPairs(int[] nums) {
        int[] count = new int[101];
        int ret = 0;
        for (int n : nums) {
            ret += count[n]++;
        }
        return ret;
    }
}
// @lc code=end

