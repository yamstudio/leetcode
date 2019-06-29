/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 */
public class Solution {
    public int Reverse(int x) {
        long ret = 0, y = (long) x;
        bool neg = x < 0;
        for (y = Math.Abs(y); y > 0; y /= 10) {
            ret = ret * 10 + y % 10;
        }
        if (neg) {
            ret = -ret;
        }
        if (ret > int.MaxValue || ret < int.MinValue) {
            return 0;
        }
        return (int) ret;
    }
}

