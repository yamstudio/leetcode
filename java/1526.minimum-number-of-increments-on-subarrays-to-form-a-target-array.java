/*
 * @lc app=leetcode id=1526 lang=java
 *
 * [1526] Minimum Number of Increments on Subarrays to Form a Target Array
 */

// @lc code=start
class Solution {
    public int minNumberOperations(int[] target) {
        int ret = target[0], n = target.length;
        for (int i = 1; i < n; ++i) {
            ret += Math.max(0, target[i] - target[i - 1]);
        }
        return ret;
    }
}
// @lc code=end

