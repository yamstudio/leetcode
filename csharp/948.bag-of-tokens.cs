/*
 * @lc app=leetcode id=948 lang=csharp
 *
 * [948] Bag of Tokens
 */

using System;

// @lc code=start
public class Solution {
    public int BagOfTokensScore(int[] tokens, int P) {
        int ret = 0, curr = 0, l = 0, r = tokens.Length - 1;
        Array.Sort(tokens);
        while (l <= r) {
            while (l <= r && tokens[l] <= P) {
                P -= tokens[l++];
                ++curr;
                ret = Math.Max(ret, curr);
            }
            if (curr == 0 || l > r) {
                break;
            }
            P += tokens[r--];
            --curr;
        }
        return ret;
    }
}
// @lc code=end

