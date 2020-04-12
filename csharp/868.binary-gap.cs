/*
 * @lc app=leetcode id=868 lang=csharp
 *
 * [868] Binary Gap
 */

using System;

// @lc code=start
public class Solution {
    public int BinaryGap(int N) {
        int ret = 0, p = 0, c = 0;
        while (N != 0) {
            ++c;
            if ((N & 1) == 1) {
                if (p > 0) {
                    ret = Math.Max(ret, c - p);
                }
                p = c;
            }
            N >>= 1;
        }
        return ret;
    }
}
// @lc code=end

