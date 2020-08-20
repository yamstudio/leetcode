/*
 * @lc app=leetcode id=1036 lang=csharp
 *
 * [1036] Escape a Large Maze
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static (int DR, int DC)[] Dirs = new (int DR, int DC)[] {
        (DR: -1, DC: 0),
        (DR: 1, DC: 0),
        (DR: 0, DC: -1),
        (DR: 0, DC: 1)
    };

    private static bool IsEscapePossibleRecurse((int R, int C) source, (int R, int C) target, (int R, int C) curr, HashSet<(int R, int C)> blocked, HashSet<(int R, int C)> visited) {
        if (curr.R < 0 || curr.R >= 1000000 || curr.C < 0 || curr.C >= 1000000 || blocked.Contains(curr) || visited.Contains(curr)) {
            return false;
        }
        if (Math.Abs(curr.R - source.R) >= 200 || Math.Abs(curr.C - source.C) >= 200 || curr.R == target.R && curr.C == target.C) {
            return true;
        }
        visited.Add(curr);
        foreach (var dir in Dirs) {
            var next = (R: curr.R + dir.DR, C: curr.C + dir.DC);
            if (IsEscapePossibleRecurse(source, target, next, blocked, visited)) {
                return true;
            }
        }
        return false;
    }

    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target) {
        var b = blocked.Select(t => (R: t[0], C: t[1])).ToHashSet();
        var s = (R: source[0], C: source[1]);
        var t = (R: target[0], C: target[1]);
        return IsEscapePossibleRecurse(s, t, s, b, new HashSet<(int R, int C)>()) && IsEscapePossibleRecurse(t, s, t, b, new HashSet<(int R, int C)>());
    }
}
// @lc code=end

