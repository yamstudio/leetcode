/*
 * @lc app=leetcode id=1569 lang=csharp
 *
 * [1569] Number of Ways to Reorder Array to Get Same BST
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int NumOfWays(IList<int> nums, int[,] choose) {
        int n = nums.Count;
        if (n <= 2) {
            return 1;
        }
        int r = nums[0];
        IList<int> left = new List<int>(), right = new List<int>();
        for (int i = 1; i < n; ++i) {
            if (nums[i] < r) {
                left.Add(nums[i]);
            } else {
                right.Add(nums[i]);
            }
        }
        long comb = ((long)NumOfWays(left, choose) * (long)NumOfWays(right, choose)) % 1000000007;
        return (int)((comb * (long)choose[n - 1, left.Count]) % 1000000007);
    }

    public int NumOfWays(int[] nums) {
        int n = nums.Length;
        var choose = new int[n, n];
        for (int i = 0; i < n; ++i) {
            choose[i, 0] = 1;
            choose[i, i] = 1;
            for (int j = 1; j < i; ++j) {
                choose[i, j] = (choose[i - 1, j - 1] + choose[i - 1, j]) % 1000000007;
            }
        }
        return NumOfWays(nums, choose) - 1;
    }
}
// @lc code=end

