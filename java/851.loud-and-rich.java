/*
 * @lc app=leetcode id=851 lang=java
 *
 * [851] Loud and Rich
 */

// @lc code=start
class Solution {

    private static int get(List<Integer>[] map, int i, int[] quiet, int[] memo) {
        if (memo[i] >= 0) {
            return quiet[memo[i]];
        }
        int ret = i;
        for (int j : map[i]) {
            if (quiet[ret] > get(map, j, quiet, memo)) {
                ret = memo[j];
            }
        }
        memo[i] = ret;
        return quiet[ret];
    }

    public int[] loudAndRich(int[][] richer, int[] quiet) {
        int n = quiet.length;
        List<Integer>[] map = new List[n];
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            ret[i] = -1;
            map[i] = new ArrayList<Integer>();
        }
        for (int[] r : richer) {
            map[r[1]].add(r[0]);
        }
        for (int i = 0; i < n; ++i) {
            get(map, i, quiet, ret);
        }
        return ret;
    }
}
// @lc code=end

