/*
 * @lc app=leetcode id=299 lang=csharp
 *
 * [299] Bulls and Cows
 */
public class Solution {
    public string GetHint(string secret, string guess) {
        int[] map = new int[10];
        int bulls = 0, cows = 0, n = secret.Length;
        for (int i = 0; i < n; ++i) {
            int s = secret[i] - '0', g = guess[i] - '0';
            if (s == g) {
                ++bulls;
            } else {
                if (map[s]++ < 0) {
                    ++cows;
                }
                if (map[g]-- > 0) {
                    ++cows;
                }
            }
        }
        return $"{bulls}A{cows}B";
    }
}

