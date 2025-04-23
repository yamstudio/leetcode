/*
 * @lc app=leetcode id=1608 lang=java
 *
 * [1608] Special Array With X Elements Greater Than or Equal X
 */

// @lc code=start

class Solution {
    public int specialArray(int[] nums) {
        int acc = 0, n = nums.length;
        int[] count = new int[1001];
        for (int x : nums) {
            ++count[x];
        }
        for (int i = 0; i <= 1000 && acc < n; ++i) {
            if (acc == n - i) {
                return i;
            }
            acc += count[i];
        }
        return -1;
    }
}
// @lc code=end

