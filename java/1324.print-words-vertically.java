/*
 * @lc app=leetcode id=1324 lang=java
 *
 * [1324] Print Words Vertically
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<String> printVertically(String s) {
        String[] split = s.split(" ");
        int k = split.length, ml = 0;
        int[] rightMaxLength = new int[k];
        for (int i = k - 1; i >= 0; --i) {
            rightMaxLength[i] = ml;
            ml = Math.max(ml, split[i].length());
        }
        List<String> ret = new ArrayList<>(ml);
        StringBuilder sb = new StringBuilder(k);
        for (int i = 0; i < ml; ++i) {
            for (int j = 0; j < k && (rightMaxLength[j] > i || split[j].length() > i); ++j) {
                sb.append(split[j].length() > i ? split[j].charAt(i) : ' ');
            }
            ret.add(sb.toString());
            sb.delete(0, sb.length());
        }
        return ret;
    }
}
// @lc code=end

