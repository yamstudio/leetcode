/*
 * @lc app=leetcode id=367 lang=csharp
 *
 * [367] Valid Perfect Square
 */

using System.Collections.Generic;

public class Solution {

    private static readonly ISet<int> set;

    static Solution() {
        set = new HashSet<int>();
        long val = 1, i = 1;
        do {
            set.Add((int) val);
            ++i;
            val = i * i;
        } while (val < int.MaxValue);
    }

    public bool IsPerfectSquare(int num) {
        return set.Contains(num);
    }
}

