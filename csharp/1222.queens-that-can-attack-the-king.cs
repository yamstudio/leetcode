/*
 * @lc app=leetcode id=1222 lang=csharp
 *
 * [1222] Queens That Can Attack the King
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
        var candidates = new int[8][];
        foreach (var queen in queens) {
            int index;
            if (queen[0] == king[0]) {
                index = queen[1] > king[1] ? 0 : 1;
            } else if (queen[1] == king[1]) {
                index = queen[0] > king[0] ? 2 : 3;
            } else if (queen[0] - king[0] == queen[1] - king[1]) {
                index = queen[0] > king[0] ? 4 : 5;
            } else if (queen[0] - king[0] == -queen[1] + king[1]) {
                index = queen[0] > king[0] ? 6 : 7;
            } else {
                continue;
            }
            if (candidates[index] == null || Math.Abs(candidates[index][0] - king[0]) + Math.Abs(candidates[index][1] - king[1]) > Math.Abs(queen[0] - king[0]) + Math.Abs(queen[1] - king[1])) {
                candidates[index] = queen;
            }
        }
        return candidates.Where(t => t != null).Select<int[], IList<int>>(t => t.ToList()).ToList();
    }
}
// @lc code=end

