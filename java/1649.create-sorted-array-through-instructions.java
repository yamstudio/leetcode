/*
 * @lc app=leetcode id=1649 lang=java
 *
 * [1649] Create Sorted Array through Instructions
 */

// @lc code=start
class Solution {
    public int createSortedArray(int[] instructions) {
        int[] fenwick = new int[100001];
        int ret = 0, n = instructions.length;
        for (int i = 0; i < n; ++i) {
            int v = instructions[i];
            ret = (ret + Math.min(get(fenwick, v - 1), i - get(fenwick, v))) % 1000000007;
            inc(fenwick, v);
        }
        return ret;
    }

    private static int get(int[] fenwick, int i) {
        int ret = 0;
        while (i > 0) {
            ret += fenwick[i];
            i -= i & (-i);
        }
        return ret;
    }

    private static void inc(int[] fenwick, int i) {
        while (i <= 100000) {
            fenwick[i]++;
            i += i & (-i);
        }
    }
}
// @lc code=end

