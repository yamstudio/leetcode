/*
 * @lc app=leetcode id=29 lang=csharp
 *
 * [29] Divide Two Integers
 */
public class Solution {
    public int Divide(int dividend, int divisor) {
        if (dividend == int.MinValue && divisor == -1) {
            return int.MaxValue;
        }
        long dvd = Math.Abs((long) dividend), dvs = Math.Abs((long) divisor), ret = 0;
        bool neg = dividend > 0 ^ divisor > 0;
        while (dvd >= dvs) {
            long tmp = dvs, res = 1;
            while (dvd >= (tmp << 1)) {
                tmp <<= 1;
                res <<= 1;
            }
            ret += res;
            dvd -= tmp;
        }
        return neg ? (int) -ret : (int) ret;
    }
}

