/*
 * @lc app=leetcode id=1262 lang=java
 *
 * [1262] Greatest Sum Divisible by Three
 */

// @lc code=start
class Solution {
    public int maxSumDivThree(int[] nums) {
        int sum = 0;
        int[] ones = new int[] { -1, -1 }, twos = new int[] { -1, -1 };
        for (int num : nums) {
            sum += num;
            if (num % 3 == 0) {
                continue;
            }
            int[] list = num % 3 == 1 ? ones : twos;
            if (list[0] == -1) {
                list[0] = num;
            } else if (num <= list[0]) {
                list[1] = list[0];
                list[0] = num;
            } else if (list[1] == -1 || num < list[1]) {
                list[1] = num;
            }
        }
        if (sum % 3 == 0) {
            return sum;
        }
        if (sum % 3 == 1) {
            if (ones[0] == -1) {
                return sum - twos[0] - twos[1];
            }
            if (twos[0] == -1) {
                return sum - ones[0];
            }
            return sum - Math.min(twos[0] + twos[1], ones[0]);
        }
        if (twos[0] == -1) {
            return sum - ones[0] - ones[1];
        }
        if (ones[0] == -1 || ones[1] == -1) {
            return sum - twos[0];
        }
        return sum - Math.min(ones[0] + ones[1], twos[0]);
    }
}
// @lc code=end

