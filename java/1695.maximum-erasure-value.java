/*
 * @lc app=leetcode id=1695 lang=java
 *
 * [1695] Maximum Erasure Value
 */

// @lc code=start
class Solution {
    public int maximumUniqueSubarray(int[] nums) {
        boolean[] contains = new boolean[100001];
        int n = nums.length, l = 0, acc = 0, ret = 0;
        for (int r = 0; r < n; ++r) {
            int x = nums[r];
            if (contains[x]) {
                while (nums[l] != x) {
                    contains[nums[l]] = false;
                    acc -= nums[l++];
                }
                ++l;
            } else {
                acc += x;
                contains[x] = true;
            }
            ret = Math.max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

