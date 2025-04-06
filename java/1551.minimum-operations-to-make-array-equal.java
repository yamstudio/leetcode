/*
 * @lc app=leetcode id=1551 lang=java
 *
 * [1551] Minimum Operations to Make Array Equal
 */

// @lc code=start
class Solution {
    public int minOperations(int n) {
        return (n + n % 2) * (n / 2) / 2;
    }
}
// @lc code=end

