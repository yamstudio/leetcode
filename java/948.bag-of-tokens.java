/*
 * @lc app=leetcode id=948 lang=java
 *
 * [948] Bag of Tokens
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int bagOfTokensScore(int[] tokens, int power) {
        int n = tokens.length, l = 0, r = n - 1, ret = 0, s = 0, p = power;
        int[] sorted = Arrays.stream(tokens).sorted().toArray();
        while (l <= r) {
            if (p >= sorted[l]) {
                p -= sorted[l++];
                ++s;
            } else {
                if (s == 0) {
                    break;
                }
                p += sorted[r--];
                --s;
            }
            ret = Math.max(ret, s);
        }
        return ret;
    }
}
// @lc code=end

