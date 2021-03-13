/*
 * @lc app=leetcode id=914 lang=java
 *
 * [914] X of a Kind in a Deck of Cards
 */

// @lc code=start
class Solution {

    private static int Gcd(int x, int y) {
        return x == 0 ? y : Gcd(y % x, x);
    }

    public boolean hasGroupsSizeX(int[] deck) {
        int g = -1;
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        for (int x : deck) {
            map.put(x, map.getOrDefault(x, 0) + 1);
        }
        for (int v : map.values()) {
            if (g < 0) {
                g = v;
            } else {
                g = Gcd(g, v);
            }
            if (g == 1) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

