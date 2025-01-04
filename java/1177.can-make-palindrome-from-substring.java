/*
 * @lc app=leetcode id=1177 lang=java
 *
 * [1177] Can Make Palindrome from Substring
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Boolean> canMakePaliQueries(String s, int[][] queries) {
        int n = s.length(), acc = 0;
        int[] states = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            acc ^= 1 << (s.charAt(i) - 'a');
            states[i + 1] = acc;
        }
        List<Boolean> ret = new ArrayList<>(queries.length);
        for (int[] query : queries) {
            int state = states[query[1] + 1] ^ states[query[0]];
            int odds = 0;
            while (state != 0) {
                odds += 1 & state;
                state >>= 1;
            }
            ret.add(odds / 2 <= query[2]);
        }
        return ret;
    }
}
// @lc code=end

