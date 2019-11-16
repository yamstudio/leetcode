/*
 * @lc app=leetcode id=672 lang=csharp
 *
 * [672] Bulb Switcher II
 */

// @lc code=start
public class Solution {
    public int FlipLights(int n, int m) {
        if (n == 0 || m == 0) {
            return 1;
        }
        if (n == 1) {
            return 2;
        }
        if (n == 2) {
            return m == 1 ? 3 : 4;
        }
        if (m == 1) {
            return 4;
        }
        if (m == 2) {
            return 7;
        }
        return 8;
    }
}
// @lc code=end

