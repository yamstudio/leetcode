/*
 * @lc app=leetcode id=1390 lang=java
 *
 * [1390] Four Divisors
 */

// @lc code=start
class Solution {
    public int sumFourDivisors(int[] nums) {
        int acc = 0;
        for (int num : nums) {
            int d = (int)Math.sqrt(num);
            if (d * d == num) {
                continue;
            }
            int div = -1;
            while (d > 1) {
                if (num % d == 0) {
                    if (div > 0) {
                        div = -1;
                        break;
                    }
                    div = d;
                }
                --d;
            }
            if (div > 0) {
                acc += 1 + num + div + num / div;
            }
        }
        return acc;
    }
}
// @lc code=end

