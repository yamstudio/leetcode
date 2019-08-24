/*
 * @lc app=leetcode id=283 lang=csharp
 *
 * [283] Move Zeroes
 */
public class Solution {
    public void MoveZeroes(int[] nums) {
        int n = nums.Length, zero = 0;
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            if (num != 0) {
                if (zero != i) {
                    nums[zero] = num;
                    nums[i] = 0;
                }
                ++zero;
            }
        }
    }
}

