/*
 * @lc app=leetcode id=1630 lang=java
 *
 * [1630] Arithmetic Subarrays
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Boolean> checkArithmeticSubarrays(int[] nums, int[] l, int[] r) {
        int n = l.length;
        List<Boolean> ret = new ArrayList<>();
        for (int i = 0; i < n; ++i) {
            int li = l[i], ri = r[i], min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
            for (int j = li; j <= ri; ++j) {
                min = Math.min(nums[j], min);
                max = Math.max(nums[j], max);
            }
            if (min == max) {
                ret.add(true);
                continue;
            }
            if ((max - min) % (ri - li) != 0) {
                ret.add(false);
                continue;
            }
            int d = (max - min) / (ri - li);
            boolean[] seen = new boolean[ri - li + 1];
            boolean good = true;
            for (int j = li; j <= ri; ++j) {
                int c = nums[j];
                if (((c - min) % d != 0) || seen[(c - min) / d]) {
                    good = false;
                    break;
                }
                seen[(c - min) / d] = true;
            }
            ret.add(good);
        }
        return ret;
    }
}
// @lc code=end

