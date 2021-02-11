/*
 * @lc app=leetcode id=858 lang=java
 *
 * [858] Mirror Reflection
 */

// @lc code=start
class Solution {

    private static int getGcd(int x, int y) {
        return x == 0 ? y : getGcd(y % x, x);
    }

    public int mirrorReflection(int p, int q) {
        int t = p * q / getGcd(p, q), rooms = t / p, reflections = t / q;
        if (rooms % 2 == 0) {
            return 0;
        }
        return 2 - reflections % 2;
    }
}
// @lc code=end

