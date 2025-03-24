/*
 * @lc app=leetcode id=1497 lang=java
 *
 * [1497] Check If Array Pairs Are Divisible by k
 */

// @lc code=start
class Solution {
    public boolean canArrange(int[] arr, int k) {
        int[] count = new int[k];
        for (int x : arr) {
            ++count[(x % k + k) % k];
        }
        if (count[0] % 2 != 0) {
            return false;
        }
        if (k % 2 == 0 && count[k / 2] % 2 != 0) {
            return false;
        }
        for (int x = k / 2; x > 0; --x) {
            if (count[x] != count[k - x]) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

