/*
 * @lc app=leetcode id=202 lang=csharp
 *
 * [202] Happy Number
 */

using System.Collections.Generic;

public class Solution {
    public bool IsHappy(int n) {
        var set = new HashSet<int>();
        while (n != 1) {
            int sum = 0;
            while (n > 0) {
                int r = n % 10;
                sum += r * r;
                n /= 10;
            }
            n = sum;
            if (set.Contains(n)) {
                break;
            }
            set.Add(n);
        }
        return n == 1;
    }
}

