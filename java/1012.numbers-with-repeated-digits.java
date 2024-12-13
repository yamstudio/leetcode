/*
 * @lc app=leetcode id=1012 lang=java
 *
 * [1012] Numbers With Repeated Digits
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int numDupDigitsAtMostN(int n) {
        String s = Integer.toString(n + 1);
        int len = s.length(), distinct = 0;
        Map<Key, Integer> memo = new HashMap<>();
        for (int l = 1; l < len; ++l) {
            distinct += countPermutation(l - 1, 9, memo) * 9;
        }
        int used = 0;
        for (int i = 0; i < len; ++i) {
            int c = s.charAt(i) - '0';
            for (int start = i == 0 ? 1 : 0; start < c; ++start) {
                if (((1 << start) & used) == 0) {
                    distinct += countPermutation(len - i - 1, 9 - i, memo);
                }
            }
            if (((1 << c) & used) != 0) {
                break;
            }
            used |= 1 << c;
        }
        return n - distinct;
    }

    private static int countPermutation(int len, int free, Map<Key, Integer> memo) {
        if (len == 0) {
            return 1;
        }
        Key key = new Key(len, free);
        Integer cached = memo.get(key);
        if (cached != null) {
            return cached;
        }
        int v = countPermutation(len - 1, free, memo) * (free - (len - 1));
        memo.put(key, v);
        return v;
    }

    private record Key(int len, int free) {}
}
// @lc code=end

