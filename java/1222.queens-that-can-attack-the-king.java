/*
 * @lc app=leetcode id=1222 lang=java
 *
 * [1222] Queens That Can Attack the King
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<List<Integer>> queensAttacktheKing(int[][] queens, int[] king) {
        int[][][] qs = new int[3][3][];
        int l = 0;
        for (int[] q : queens) {
            int r = q[0] - king[0], c = q[1] - king[1], rk, ck;
            if (r == 0) {
                rk = 0;
                ck = c > 0 ? 1 : -1;
            } else if (c == 0) {
                ck = 0;
                rk = r > 0 ? 1 : -1;
            } else if (Math.abs(r) == Math.abs(c)) {
                rk = r / Math.abs(r);
                ck = c / Math.abs(c);
            } else {
                continue;
            }
            rk++;
            ck++;
            int[] e = qs[rk][ck];
            if (e == null) {
                ++l;
            }
            if (e == null || (Math.abs(e[0] - king[0]) >= Math.abs(r) && Math.abs(e[1] - king[1]) >= Math.abs(c))) {
                qs[rk][ck] = q;
            }
        }
        List<List<Integer>> ret = new ArrayList<>(l);
        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 3; ++j) {
                int[] q = qs[i][j];
                if (q != null) {
                    ret.add(List.of(q[0], q[1]));
                }
            }
        }
        return ret;
    }
}
// @lc code=end

