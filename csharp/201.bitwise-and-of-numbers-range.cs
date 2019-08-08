/*
 * @lc app=leetcode id=201 lang=csharp
 *
 * [201] Bitwise AND of Numbers Range
 */
public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
        int mask = int.MaxValue;
        while ((m & mask) != (n & mask)) {
            mask <<= 1;
        }
        return n & mask;
    }
}

