/*
 * @lc app=leetcode id=416 lang=csharp
 *
 * [416] Partition Equal Subset Sum
 */
public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = 0;
        foreach (int num in nums) {
            sum += num;
        }
        if (sum % 2 == 1) {
            return false;
        }
        sum /= 2;
        bool[] dp = new bool[sum + 1];
        dp[0] = true;
        foreach (int num in nums) {
            for (int i = sum; i >= num; --i) {
                dp[i] |= dp[i - num];
            }
        }
        return dp[sum];
    }
}

