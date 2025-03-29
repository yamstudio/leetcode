/*
 * @lc app=leetcode id=1509 lang=java
 *
 * [1509] Minimum Difference Between Largest and Smallest Value in Three Moves
 */

// @lc code=start
class Solution {
    public int minDifference(int[] nums) {
        if (nums.length < 5) {
            return 0;
        }
        int[] min = new int[] {
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE
        }, max = new int[] {
            Integer.MIN_VALUE,
            Integer.MIN_VALUE,
            Integer.MIN_VALUE,
            Integer.MIN_VALUE
        };
        for (int x : nums) {
            if (x < min[0]) {
                min[3] = min[2];
                min[2] = min[1];
                min[1] = min[0];
                min[0] = x;
            } else if (x < min[1]) {
                min[3] = min[2];
                min[2] = min[1];
                min[1] = x;
            } else if (x < min[2]) {
                min[3] = min[2];
                min[2] = x;
            } else if (x < min[3]) {
                min[3] = x;
            }
            if (x > max[0]) {
                max[3] = max[2];
                max[2] = max[1];
                max[1] = max[0];
                max[0] = x;
            } else if (x > max[1]) {
                max[3] = max[2];
                max[2] = max[1];
                max[1] = x;
            } else if (x > max[2]) {
                max[3] = max[2];
                max[2] = x;
            } else if (x > max[3]) {
                max[3] = x;
            }
        }
        return Math.min(max[3] - min[0], Math.min(max[2] - min[1], Math.min(max[1] - min[2], max[0] - min[3])));
    }
}
// @lc code=end

