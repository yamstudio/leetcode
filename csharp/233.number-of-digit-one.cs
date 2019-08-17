/*
 * @lc app=leetcode id=233 lang=csharp
 *
 * [233] Number of Digit One
 */
public class Solution {
    public int CountDigitOne(int n) {
        int ret = 0, ten = 1, rem = 1;
        while (n > 0) {
            ret += (n + 8) / 10 * ten;
            if (n % 10 == 1) {
                ret += rem;
            }
            rem += n % 10 * ten;
            ten *= 10;
            n /= 10;
        }
        return ret;
    }
}

