/*
 * @lc app=leetcode id=954 lang=java
 *
 * [954] Array of Doubled Pairs
 */

import java.util.List;
import java.util.TreeMap;

// @lc code=start
class Solution {
    public boolean canReorderDoubled(int[] arr) {
        TreeMap<Integer, Integer> pos = new TreeMap<>();
        TreeMap<Integer, Integer> neg = new TreeMap<>();
        int zeroCount = 0, posCount = 0, negCount = 0;
        for (int x : arr) {
            if (x == 0) {
                ++zeroCount;
            } else if (x > 0) {
                ++posCount;
                pos.put(x, pos.getOrDefault(x, 0) + 1);
            } else {
                ++negCount;
                neg.put(-x, neg.getOrDefault(-x, 0) + 1);
            }
        }
        if (zeroCount % 2 == 1 || posCount % 2 == 1 || negCount % 2 == 1) {
            return false;
        }
        return canReorderDoubled(pos) && canReorderDoubled(neg); 
    }

    private static boolean canReorderDoubled(TreeMap<Integer, Integer> vals) {
        List<Integer> keys = vals.keySet().stream().toList();
        for (int key : keys) {
            if (!vals.containsKey(key)) {
                continue;
            }
            int doubled = 2 * key;
            if (!vals.containsKey(doubled)) {
                return false;
            }
            int val = vals.get(key), doubleVal = vals.get(doubled);
            if (doubleVal < val) {
                return false;
            }
            vals.remove(key);
            if (doubleVal == val) {
                vals.remove(doubled);
            } else {
                vals.put(doubled, doubleVal - val);
            }
        }
        return true;
    }
}
// @lc code=end

