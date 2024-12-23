/*
 * @lc app=leetcode id=1073 lang=java
 *
 * [1073] Adding Two Negabinary Numbers
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class Solution {
    public int[] addNegabinary(int[] arr1, int[] arr2) {
        List<Integer> ret = new ArrayList<>();
        for (int i = arr1.length - 1, j = arr2.length - 1, carry = 0; i >= 0 || j >= 0 || carry != 0; --i, --j) {
            if (i >= 0) {
                carry += arr1[i];
            }
            if (j >= 0) {
                carry += arr2[j];
            }
            ret.add(carry & 1);
            carry = -(carry >> 1);
        }
        int l = ret.size() - 1;
        while (l > 0 && ret.get(l) == 0) {
            --l;
        }
        int[] arr = new int[l + 1];
        for (int i = 0; i <= l; ++i) {
            arr[i] = ret.get(l - i);
        }
        return arr;
    }
}
// @lc code=end

