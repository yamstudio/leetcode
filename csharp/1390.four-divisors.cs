/*
 * @lc app=leetcode id=1390 lang=csharp
 *
 * [1390] Four Divisors
 */

// @lc code=start
public class Solution {
    public int SumFourDivisors(int[] nums) {
        int ret = 0;
        foreach (int num in nums) {
            int d = -1;
            for (int i = 2; i * i <= num; ++i) {
                if (num % i == 0) {
                    if (d == -1) {
                        d = i;
                    } else {
                        d = -1;
                        break;
                    }
                }
            }
            if (d > 0 && d * d != num) {
                ret += 1 + num + d + num / d;
            }
        }
        return ret;
    }
}
// @lc code=end

