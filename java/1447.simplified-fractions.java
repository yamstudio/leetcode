/*
 * @lc app=leetcode id=1447 lang=java
 *
 * [1447] Simplified Fractions
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<String> simplifiedFractions(int n) {
        List<String> ret = new ArrayList<>();
        for (int d = 2; d <= n; ++d) {
            for (int k = 1; k < d; ++k) {
                if (gcd(k, d) == 1) {
                    ret.add(k + "/" + d);
                }
            }
        }
        return ret;
    }

    private static int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }
}
// @lc code=end

