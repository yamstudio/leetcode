/*
 * @lc app=leetcode id=1674 lang=java
 *
 * [1674] Minimum Moves to Make Array Complementary
 */

// @lc code=start
class Solution {
    public int minMoves(int[] nums, int limit) {
        int n = nums.length, ll = limit * 2;
        int[] count = new int[ll + 2];
        for (int i = 0; i * 2 < n; ++i) {
            int a = nums[i], b = nums[n - 1 - i];
            --count[a + b];
            --count[Math.min(a, b) + 1];
            ++count[a + b + 1];
            ++count[Math.max(a, b) + limit + 1];
        }
        int ret = n, acc = n;
        for (int i = 2; i <= ll; ++i) {
            acc += count[i];
            ret = Math.min(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

