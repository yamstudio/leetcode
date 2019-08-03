/*
 * @lc app=leetcode id=172 lang=csharp
 *
 * [172] Factorial Trailing Zeroes
 */
public class Solution {
    public int TrailingZeroes(int n) {
        long five = 5, ret = 0, nl = (long) n;
        while (five <= nl) {
            ret += nl / five;
            five *= 5;
        }
        return (int) ret;
    }
}

