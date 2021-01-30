/*
 * @lc app=leetcode id=821 lang=java
 *
 * [821] Shortest Distance to a Character
 */

// @lc code=start
class Solution {
    public int[] shortestToChar(String S, char C) {
        List<Integer> indices = new ArrayList<Integer>();
        int n = S.length(), k = 1;
        int[] ret = new int[n];
        indices.add(-n);
        for (int i = 0; i < n; ++i) {
            if (S.charAt(i) == C) {
                indices.add(i);
            }
        }
        indices.add(2 * n);
        for (int i = 0; i < n; ++i) {
            ret[i] = Math.min(i - indices.get(k - 1), indices.get(k) - i);
            if (indices.get(k) == i) {
                ++k;
            }
        }
        return ret;
    }
}
// @lc code=end

