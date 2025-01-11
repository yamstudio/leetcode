/*
 * @lc app=leetcode id=1220 lang=java
 *
 * [1220] Count Vowels Permutation
 */

import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start

class Solution {

    private static Map<Character, List<Character>> nexts = Map.of(
        'a', List.of('e'),
        'e', List.of('a', 'i'),
        'i', List.of('a', 'e', 'o', 'u'),
        'o', List.of('i', 'u'),
        'u', List.of('a')
    );

    public int countVowelPermutation(int n) {
        int ret = 0;
        Map<String, Integer> memo = new HashMap<>();
        for (char c : nexts.keySet()) {
            ret = (ret + count(c, n - 1, memo)) % 1000000007;
        }
        return ret;
    }

    private static int count(char c, int l, Map<String, Integer> memo) {
        if (l == 0) {
            return 1;
        }
        String k = "%s%d".formatted(c, l);
        Integer cached = memo.get(k);
        if (cached != null) {
            return cached;
        }
        int ret = 0;
        for (char next : nexts.get(c)) {
            ret = (ret + count(next, l - 1, memo)) % 1000000007; 
        }
        memo.put(k, ret);
        return ret;
    }
}
// @lc code=end

