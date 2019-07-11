/*
 * @lc app=leetcode id=69 lang=csharp
 *
 * [69] Sqrt(x)
 */
public class Solution {
    public int MySqrt(int x) {
        long ret = x;
        while (ret * ret > (long) x) {
            ret = (ret + x / ret) / 2;
        }
        return (int) ret;
    }
}

