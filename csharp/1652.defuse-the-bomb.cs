/*
 * @lc app=leetcode id=1652 lang=csharp
 *
 * [1652] Defuse the Bomb
 */

using System;

// @lc code=start
public class Solution {
    public int[] Decrypt(int[] code, int k) {
        int n = code.Length, acc = 0;
        int[] ret = new int[n];
        if (k == 0) {
            return ret;
        }
        if (k > 0) {
            for (int i = 0; i < k; ++i) {
                acc += code[i];
            }
            for (int i = 0; i < n; ++i) {
                acc = acc - code[i] + code[(i + k) % n];
                ret[i] = acc;
            }
        } else {
            for (int i = -1; i >= k; --i) {
                acc += code[n + i];
            }
            for (int i = 0; i < n; ++i) {
                ret[i] = acc;
                acc = acc + code[i] - code[(i + n + k) % n];
            }
        }
        return ret;
    }
}
// @lc code=end

