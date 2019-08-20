/*
 * @lc app=leetcode id=260 lang=csharp
 *
 * [260] Single Number III
 */

using System.Linq;

public class Solution {
    public int[] SingleNumber(int[] nums) {
        int diff = nums.Aggregate(0, (ret, num) => ret ^ num);
        diff &= -diff;
        return nums.Aggregate(new int[2], (ret, num) => ((num & diff) == 0 ? new int[] { ret[0] ^ num, ret[1] } : new int[] { ret[0], ret[1] ^ num }));
    }
}

