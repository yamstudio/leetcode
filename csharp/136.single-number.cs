/*
 * @lc app=leetcode id=136 lang=csharp
 *
 * [136] Single Number
 */

using System.Linq;

public class Solution {
    public int SingleNumber(int[] nums) {
        return nums.Aggregate(0, (ret, num) => ret ^ num);
    }
}

