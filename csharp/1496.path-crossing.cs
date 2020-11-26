/*
 * @lc app=leetcode id=1496 lang=csharp
 *
 * [1496] Path Crossing
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool IsPathCrossing(string path) {
        var point = new HashSet<(int X, int Y)>() { (X: 0, Y: 0) };
        int x = 0, y = 0;
        foreach (char c in path) {
            switch (c) {
                case 'N':
                    ++y;
                    break;
                case 'S':
                    --y;
                    break;
                case 'W':
                    --x;
                    break;
                case 'E':
                    ++x;
                    break;
                default:
                    break;
            }
            if (!point.Add((X: x, Y: y))) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

