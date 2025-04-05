/*
 * @lc app=leetcode id=1545 lang=java
 *
 * [1545] Find Kth Bit in Nth Binary String
 */

// @lc code=start
class Solution {
    public char findKthBit(int n, int k) {
        if (n == 1) {
            return '0';
        }
        int mid = 1 << (n - 1);
        if (k == mid) {
            return '1';
        }
        if (k < mid) {
            return findKthBit(n - 1, k);
        }
        return (char)('0' + '1' - findKthBit(n - 1, mid - (k - mid)));
    }
}
// @lc code=end

