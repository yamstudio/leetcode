/*
 * @lc app=leetcode id=1496 lang=java
 *
 * [1496] Path Crossing
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public boolean isPathCrossing(String path) {
        Set<String> visited = new HashSet<>();
        int x = 0, y = 0, n = path.length();
        visited.add("0,0");
        for (int i = 0; i < n; ++i) {
            switch (path.charAt(i)) {
                case 'N':
                    ++y;
                    break;
                case 'S':
                    --y;
                    break;
                case 'W':
                    --x;
                    break;
                default:
                    ++x;
            }
            if (!visited.add("%d,%d".formatted(x, y))) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

