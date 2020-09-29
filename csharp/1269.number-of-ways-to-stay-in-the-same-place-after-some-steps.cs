/*
 * @lc app=leetcode id=1269 lang=csharp
 *
 * [1269] Number of Ways to Stay in the Same Place After Some Steps
 */

using System;

// @lc code=start
public class Solution {
    public int NumWays(int steps, int arrLen) {
        arrLen = Math.Min(arrLen, steps / 2 + 1);
        int[] prev = new int[arrLen], curr = new int[arrLen];
        prev[0] = 1;
        while (steps-- > 0) {
            for (int i = 0; i < arrLen; ++i) {
                int c = 0;
                if (i > 0) {
                    c = prev[i - 1];
                }
                c = (c + prev[i]) % 1000000007;
                if (i + 1 < arrLen) {
                    c = (c + prev[i + 1]) % 1000000007;
                }
                curr[i] = c;
            }
            var tmp = curr;
            curr = prev;
            prev = tmp;
        }
        return prev[0];
    }
}
// @lc code=end

