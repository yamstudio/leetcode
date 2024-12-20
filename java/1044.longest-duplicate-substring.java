/*
 * @lc app=leetcode id=1044 lang=java
 *
 * [1044] Longest Duplicate Substring
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start

class Solution {
    public String longestDupSubstring(String s) {
        int n = s.length();
        long[] powers = new long[n + 1];
        powers[0] = 1L;
        for (int i = 1; i <= n; ++i) {
            powers[i] = (31 * powers[i - 1]) % 1000000009L;
        }
        long[] prefixHashes = new long[n + 1];
        for (int i = 1; i <= n; ++i) {
            prefixHashes[i] = (prefixHashes[i - 1] + (s.charAt(i - 1) - 'a' + 1) * powers[i - 1]) % 1000000009L;
        }
        int l = 1, r = n - 1;
        Map<Long, Set<Integer>> matches = new HashMap<>();
        String ret = "";
        while (l <= r) {
            int len = (l + r) / 2;
            String found = null;
            for (int i = 0; i + len <= n && found == null; ++i) {
                long hash = ((prefixHashes[i + len] - prefixHashes[i] + 1000000009L) % 1000000009L) * powers[n - len - i] % 1000000009L;
                Set<Integer> existing = matches.get(hash);
                if (existing == null) {
                    existing = new HashSet<>();
                    existing.add(i);
                    matches.put(hash, existing);
                    continue;
                }
                for (int j : existing) {
                    int z;
                    for (z = 0; z < len && s.charAt(j + z) == s.charAt(i + z); ++z) {}
                    if (z == len) {
                        found = s.substring(i, i + len);
                        break;
                    }
                }
                existing.add(i);
            }
            if (found != null) {
                l = len + 1;
                ret = found;
            } else {
                r = len - 1;
            }
            matches.clear();
        }
        return ret;
    }
}
// @lc code=end

