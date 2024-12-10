/*
 * @lc app=leetcode id=1001 lang=java
 *
 * [1001] Grid Illumination
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start

class Solution {
    public int[] gridIllumination(int n, int[][] lamps, int[][] queries) {
        int q = queries.length;
        int[] ret = new int[q];
        Set<Lamp> lit = new HashSet<>();
        Map<Key, Integer> count = new HashMap<>();
        for (int[] lamp : lamps) {
            light(lamp[0], lamp[1], lit, count);
        }
        for (int i = 0; i < q; ++i) {
            int r = queries[i][0], c = queries[i][1];
            if (!isLit(r, c, count)) {
                continue;
            }
            ret[i] = 1;
            unlight(r - 1, c - 1, lit, count);
            unlight(r - 1, c, lit, count);
            unlight(r - 1, c + 1, lit, count);
            unlight(r, c - 1, lit, count);
            unlight(r, c, lit, count);
            unlight(r, c + 1, lit, count);
            unlight(r + 1, c - 1, lit, count);
            unlight(r + 1, c, lit, count);
            unlight(r + 1, c + 1, lit, count);
        }
        return ret;
    }

    private static boolean isLit(int r, int c, Map<Key, Integer> count) {
        for (Key key : getKeys(r, c)) {
            if (count.getOrDefault(key, 0) > 0) {
                return true;
            }
        }
        return false;
    }

    private static void light(int r, int c, Set<Lamp> lit, Map<Key, Integer> count) {
        if (!lit.add(new Lamp(r, c))) {
            return;
        }
        for (Key key : getKeys(r, c)) {
            count.put(key, count.getOrDefault(key, 0) + 1);
        }
    }

    private static void unlight(int r, int c, Set<Lamp> lit, Map<Key, Integer> count) {
        if (!lit.remove(new Lamp(r, c))) {
            return;
        }
        for (Key key : getKeys(r, c)) {
            count.put(key, count.get(key) - 1);
        }
    }

    private static List<Key> getKeys(int r, int c) {
        return List.of(
            new Key(0, r),
            new Key(1, c),
            new Key(2, r + c),
            new Key(3, r - c)
        );
    }

    private record Lamp(int r, int c) {}
    private record Key(int dir, int index) {}
}
// @lc code=end

