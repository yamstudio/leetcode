/*
 * @lc app=leetcode id=1461 lang=java
 *
 * [1461] Check If a String Contains All Binary Codes of Size K
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public boolean hasAllCodes(String s, int k) {
        Set<Integer> seen = new HashSet<>();
        int acc = 0, mask = (1 << k) - 1, n = s.length();
        for (int i = 0; i < n; ++i) {
            acc = ((acc << 1) | (s.charAt(i) == '1' ? 1 : 0)) & mask;
            if (i >= k - 1) {
                seen.add(acc);
            }
        }
        return seen.size() == (1 << k);
    }
}
// @lc code=end

