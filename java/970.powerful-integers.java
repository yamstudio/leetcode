/*
 * @lc app=leetcode id=970 lang=java
 *
 * [970] Powerful Integers
 */

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start

class Solution {
    public List<Integer> powerfulIntegers(int x, int y, int bound) {
        Set<Integer> ret = new HashSet<>();
        for (int a = 1; a < bound; a *= x) {
            for (int b = 1; b + a <= bound; b *= y) {
                ret.add(a + b);
                if (y == 1) {
                    break;
                }
            }
            if (x == 1) {
                break;
            }
        }
        return new ArrayList<>(ret);
    }
}
// @lc code=end

