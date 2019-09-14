/*
 * @lc app=leetcode id=403 lang=csharp
 *
 * [403] Frog Jump
 */

using System.Collections.Generic;

public class Solution {
    
    private bool CanCrossRecurse(int[] stones, ISet<(int, int)> noCross, int start, int step) {
        var key = (start, step);
        if (noCross.Contains(key)) {
            return false;
        }
        if (start == stones.Length - 1) {
            return true;
        }
        int curr = stones[start];
        for (int i = start + 1; i < stones.Length; ++i) {
            int diff = stones[i] - curr;
            if (diff < step - 1) {
                continue;
            }
            if (diff > step + 1) {
                noCross.Add(key);
                return false;
            }
            if (CanCrossRecurse(stones, noCross, i, diff)) {
                return true;
            }
        }
        noCross.Add(key);
        return false;
    }
    
    public bool CanCross(int[] stones) {
        return CanCrossRecurse(stones, new HashSet<(int, int)>(), 0, 0);
    }
}

