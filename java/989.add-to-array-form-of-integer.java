/*
 * @lc app=leetcode id=989 lang=java
 *
 * [989] Add to Array-Form of Integer
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start

class Solution {
    public List<Integer> addToArrayForm(int[] num, int k) {
        List<Integer> ret = new ArrayList<>();
        int inc = 0;
        for (int i = num.length - 1; i >= 0; --i) {
            int n = num[i], d = k % 10, s = inc + d + n;
            if (s >= 10) {
                inc = 1;
                s -= 10;
            } else {
                inc = 0;
            }
            k /= 10;
            ret.add(s);
        }
        while (k > 0 || inc > 0) {
            int d = k % 10, s = inc + d;
            if (s >= 10) {
                inc = 1;
                s -= 10;
            } else {
                inc = 0;
            }
            k /= 10;
            ret.add(s);
        }
        Collections.reverse(ret);
        return ret;
    }
}
// @lc code=end

