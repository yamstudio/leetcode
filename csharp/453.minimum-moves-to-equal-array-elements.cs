/*
 * @lc app=leetcode id=453 lang=csharp
 *
 * [453] Minimum Moves to Equal Array Elements
 */
public class Solution {
    public int MinMoves(int[] nums) {
        long sum = 0, min = int.MaxValue;
        foreach (int num in nums) {
            min = Math.Min(min, (long) num);
            sum += (long) num;
        }
        return (int) (sum - min * (long) nums.Length);
    }
}

