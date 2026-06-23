/*
 * @lc app=leetcode id=1770 lang=java
 *
 * [1770] Maximum Score from Performing Multiplication Operations
 */

// @lc code=start
class Solution {
    public int maximumScore(int[] nums, int[] multipliers) {
        int m = multipliers.length;
        return maximumScore(nums, multipliers, 0, 0, new Integer[m][m]);
    }

    private static int maximumScore(int[] nums, int[] multipliers, int i, int l, Integer[][] memo) {
        int m = multipliers.length;
        if (i == m) {
            return 0;
        }
        Integer v = memo[i][l];
        if (v != null) {
            return v;
        }
        v = Math.max(
            nums[nums.length - (i - l) - 1] * multipliers[i] + maximumScore(nums, multipliers, i + 1, l, memo),
            nums[l] * multipliers[i] + maximumScore(nums, multipliers, i + 1, l + 1, memo)
        );
        memo[i][l] = v;
        return v;
    }
}
// @lc code=end

