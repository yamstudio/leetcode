/*
 * @lc app=leetcode id=1663 lang=csharp
 *
 * [1663] Smallest String With A Given Numeric Value
 */

using System;

// @lc code=start
public class Solution {
    public string GetSmallestString(int n, int k) {
        char[] ret = new char[n];
        k -= n;
        for (int i = 0; i < n; ++i) {
            ret[i] = (char)((int)'a' + Math.Min(25, Math.Max(0, k - 25 * (n - 1 - i))));
        }
        return new string(ret);
    }
}
// @lc code=end

