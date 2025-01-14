/*
 * @lc app=leetcode id=1239 lang=java
 *
 * [1239] Maximum Length of a Concatenated String with Unique Characters
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public int maxLength(List<String> arr) {
        List<Integer> bits = new ArrayList<>();
        for (String s : arr) {
            int l = s.length(), i, acc = 0;
            for (i = 0; i < l; ++i) {
                int k = s.charAt(i) - 'a';
                if (((1 << k) & acc) != 0) {
                    break;
                }
                acc |= (1 << k);
            }
            if (i != l) {
                continue;
            }
            bits.add(acc);
        }
        return helper(bits, 0, 0);
    }

    private static int helper(List<Integer> bits, int start, int acc) {
        int ret = 0, n = bits.size();
        for (int i = start; i < n; ++i) {
            int curr = bits.get(i);
            if ((acc & curr) == 0) {
                ret = Math.max(ret, helper(bits, i + 1, acc | curr));
            }
        }
        if (ret == 0) {
            while (acc != 0) {
                ret += acc & 1;
                acc >>= 1;
            }
        }
        return ret;
    }
}
// @lc code=end

