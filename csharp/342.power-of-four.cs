/*
 * @lc app=leetcode id=342 lang=csharp
 *
 * [342] Power of Four
 */

using System.Collections.Generic;

public class Solution {

    private static ISet<int> Powers;

    static Solution() {
        Powers = new HashSet<int>();
        long curr = 1;
        do {
            Powers.Add((int) curr);
            curr *= 4;
        } while (curr <= int.MaxValue);
    }

    public bool IsPowerOfFour(int num) {
        return Powers.Contains(num);
    }
}

