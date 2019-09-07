/*
 * @lc app=leetcode id=365 lang=csharp
 *
 * [365] Water and Jug Problem
 */
public class Solution {

    private static int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }

    public bool CanMeasureWater(int x, int y, int z) {
        return z == 0 || (x + y >= z && z % gcd(x, y) == 0);
    }
}

