/*
 * @lc app=leetcode id=343 lang=csharp
 *
 * [343] Integer Break
 */
public class Solution {
    public int IntegerBreak(int n) {
        if (n < 4) {
            return n - 1;
        }
        int ret = 1;
        while (n > 4) {
            ret *= 3;
            n -= 3;
        }
        return ret * n;
    }
}

