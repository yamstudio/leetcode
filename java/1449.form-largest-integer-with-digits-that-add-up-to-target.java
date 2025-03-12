/*
 * @lc app=leetcode id=1449 lang=java
 *
 * [1449] Form Largest Integer With Digits That Add up to Target
 */

// @lc code=start
class Solution {
    public String largestNumber(int[] cost, int target) {
        int[] digits = new int[target + 1];
        for (int i = 1; i <= target; ++i) {
            int d = -1000000;
            for (int c = 0; c < 9; ++c) {
                if (i >= cost[c]) {
                    d = Math.max(d, 1 + digits[i - cost[c]]);
                }
            }
            digits[i] = d;
        }
        if (digits[target] <= 0) {
            return "0";
        }
        StringBuilder sb = new StringBuilder(digits[target]);
        for (int c = 8; c >= 0; --c) {
            while (target > 0 && target >= cost[c] && digits[target] == 1 + digits[target - cost[c]]) {
                sb.append(c + 1);
                target -= cost[c];
            }
        }
        return sb.toString();
    }
}
// @lc code=end

