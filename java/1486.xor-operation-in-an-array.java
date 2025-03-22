/*
 * @lc app=leetcode id=1486 lang=java
 *
 * [1486] XOR Operation in an Array
 */

// @lc code=start
class Solution {
    public int xorOperation(int n, int start) {
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            ret ^= (start + 2 * i);
        }
        return ret;
    }
}
// @lc code=end

