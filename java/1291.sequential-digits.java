/*
 * @lc app=leetcode id=1291 lang=java
 *
 * [1291] Sequential Digits
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> sequentialDigits(int low, int high) {
        if (low >= 1_000_000_000) {
            return Collections.emptyList();
        }
        int lowDigits = (int)Math.log10(low) + 1, curr = 1, inc = 1;
        for (int i = 2; i <= lowDigits; ++i) {
            curr = curr * 10 + i;
            inc = inc * 10 + 1;
        }
        int base = curr;
        List<Integer> ret = new ArrayList<>();
        while (curr <= high) {
            if (curr >= low) {
                ret.add(curr);
            }
            if (curr % 10 < 9) {
                curr += inc;
            } else {
                curr = (base * 10) + base % 10 + 1;
                inc = inc * 10 + 1;
                base = curr;
            }
        }
        return ret;
    }
}
// @lc code=end

