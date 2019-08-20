/*
 * @lc app=leetcode id=264 lang=csharp
 *
 * [264] Ugly Number II
 */

using System.Collections.Generic;

public class Solution {
    private static readonly int[] Uglies;

    static Solution() {
        Uglies = new int[1690];
        Uglies[0] = 1;
        int i2 = 0, i3 = 0, i5 = 0;
        for (int i = 1; i < 1690; ++i) {
            int n2 = Uglies[i2] * 2, n3 = Uglies[i3] * 3, n5 = Uglies[i5] * 5, n = Math.Min(n2, Math.Min(n3, n5));
            if (n2 == n) {
                ++i2;
            }
            if (n3 == n) {
                ++i3;
            }
            if (n5 == n) {
                ++i5;
            }
            Uglies[i] = n;
        }
    }
    
    public int NthUglyNumber(int n) {
        return Uglies[n - 1];
    }
}

