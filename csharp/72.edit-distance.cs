/*
 * @lc app=leetcode id=72 lang=csharp
 *
 * [72] Edit Distance
 */
public class Solution {
    public int MinDistance(string word1, string word2) {
        int[] dp = new int[word1.Length + 1];
        for (int i = 0; i <= word1.Length; ++i) {
            dp[i] = i;
        }
        for (int j = 0; j < word2.Length; ++j) {
            char c = word2[j];
            int prev = dp[0];
            dp[0] = j + 1;
            for (int i = 1; i <= word1.Length; ++i) {
                int curr = dp[i];
                dp[i] = Math.Min(prev + (word1[i - 1] == c ? 0 : 1), Math.Min(dp[i], dp[i - 1]) + 1);
                prev = curr;
            }
        }
        return dp[word1.Length];
    }
}

