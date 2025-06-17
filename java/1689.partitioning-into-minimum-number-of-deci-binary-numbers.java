/*
 * @lc app=leetcode id=1689 lang=java
 *
 * [1689] Partitioning Into Minimum Number Of Deci-Binary Numbers
 */

// @lc code=start
class Solution {
    public int minPartitions(String n) {
        int k = n.length(), ret = 0;
        for (int i = 0; i < k; ++i) {
            ret = Math.max(ret, n.charAt(i) - '0');
        }
        return ret;
    }
}
// @lc code=end

