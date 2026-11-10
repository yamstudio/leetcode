/*
 * @lc app=leetcode id=1835 lang=java
 *
 * [1835] Find XOR Sum of All Pairs Bitwise AND
 */

// @lc code=start
class Solution {
    public int getXORSum(int[] arr1, int[] arr2) {
        int acc1 = 0, acc2 = 0;
        for (int x : arr1) {
            acc1 ^= x;
        }
        for (int x : arr2) {
            acc2 ^= x;
        }
        return acc1 & acc2;
    }
}
// @lc code=end

