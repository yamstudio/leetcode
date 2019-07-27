/*
 * @lc app=leetcode id=137 lang=csharp
 *
 * [137] Single Number II
 */

using System.Linq;

public class Solution {
    public int SingleNumber(int[] nums) {
        return nums.Aggregate(new int[] {0, 0}, (ret, num) => {
            int twos = ret[0], ones = ret[1];
            ones = (ones ^ num) & ~twos;
            twos = (twos ^ num) & ~ones;
            return new int[] { twos, ones };
        })[1];
    }
}

