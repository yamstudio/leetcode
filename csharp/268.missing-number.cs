/*
 * @lc app=leetcode id=268 lang=csharp
 *
 * [268] Missing Number
 */

using System.Linq;

public class Solution {
    public int MissingNumber(int[] nums) {
        return (1 + nums.Length) * nums.Length / 2 - nums.Aggregate((ret, num) => ret + num);
    }
}

