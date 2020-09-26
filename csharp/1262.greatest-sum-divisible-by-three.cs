/*
 * @lc app=leetcode id=1262 lang=csharp
 *
 * [1262] Greatest Sum Divisible by Three
 */

using System;

// @lc code=start
public class Solution {
    public int MaxSumDivThree(int[] nums) {
        int sum = 0;
        int[] ones = new int[] { -1, -1 }, twos = new int[] { -1, -1 };
        foreach (int x in nums) {
            sum += x;
            int[] l;
            if (x % 3 == 0) {
                continue;
            } else if (x % 3 == 1) {
                l = ones;
            } else {
                l = twos;
            }
            if (l[0] == -1) {
                l[0] = x;
            } else if (x <= l[0]) {
                l[1] = l[0];
                l[0] = x;
            } else if (l[1] == -1 || x < l[1]) {
                l[1] = x;
            }
        }
        if (sum % 3 == 0) {
            return sum;
        }
        if (sum % 3 == 1) {
            if (ones[0] == -1) {
                return sum - twos[0] - twos[1];
            } else if (twos[0] == -1) {
                return sum - ones[0];
            } else {
                return sum - Math.Min(ones[0], twos[0] + twos[1]);
            }
        }
        if (twos[0] == -1) {
            return sum - ones[0] - ones[1];
        } else if (ones[0] == -1 || ones[1] == -1) {
            return sum - twos[0];
        } else {
            return sum - Math.Min(twos[0], ones[0] + ones[1]);
        }
    }
}
// @lc code=end

