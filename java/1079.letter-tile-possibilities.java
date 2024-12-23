/*
 * @lc app=leetcode id=1079 lang=java
 *
 * [1079] Letter Tile Possibilities
 */

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

// @lc code=start

import static java.util.stream.Collectors.joining;

class Solution {
    public int numTilePossibilities(String tiles) {
        int[] count = new int[26];
        int n = tiles.length();
        for (int i = 0; i < n; ++i) {
            ++count[tiles.charAt(i) - 'A'];
        }
        return helper(count, new HashMap<>()) - 1;
    }

    private static int helper(int[] count, Map<String, Integer> memo) {
        String key = toKey(count);
        Integer cached = memo.get(key);
        if (cached != null) {
            return cached;
        }
        int ret = 1;
        for (int i = 0; i < 26; ++i) {
            if (count[i] == 0) {
                continue;
            }
            --count[i];
            ret += helper(count, memo);
            ++count[i];
        }
        memo.put(key, ret);
        return ret;
    }

    private static String toKey(int[] count) {
        return Arrays.stream(count).sorted().mapToObj(Integer::toString).collect(joining("|"));
    }
}
// @lc code=end

