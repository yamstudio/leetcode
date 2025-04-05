/*
 * @lc app=leetcode id=1542 lang=java
 *
 * [1542] Find Longest Awesome Substring
 */

import java.util.Set;

// @lc code=start

class Solution {
    private static final Set<Integer> GOOD = Set.of(
        0,
        1,
        2,
        4,
        8,
        16,
        32,
        64,
        128,
        256,
        512
    );

    public int longestAwesome(String s) {
        int n = s.length(), acc = 0, ret = 0;
        int[] lastIndex = new int[1024];
        lastIndex[0] = 1;
        for (int i = 0; i < n; ++i) {
            acc ^= 1 << (s.charAt(i) - '0');
            for (int state : GOOD) {
                int mask = state ^ acc;
                if (lastIndex[mask] == 0) {
                    continue;
                }
                ret = Math.max(ret, i + 2 - lastIndex[mask]);
            }
            if (lastIndex[acc] == 0) {
                lastIndex[acc] = i + 2;
            }
        }
        return ret;
    }
}
// @lc code=end

