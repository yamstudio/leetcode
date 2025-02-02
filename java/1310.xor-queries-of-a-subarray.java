/*
 * @lc app=leetcode id=1310 lang=java
 *
 * [1310] XOR Queries of a Subarray
 */

// @lc code=start
class Solution {
    public int[] xorQueries(int[] arr, int[][] queries) {
        int n = arr.length, k = queries.length;
        int[] xors = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            xors[i + 1] = xors[i] ^ arr[i];
        }
        int[] ret = new int[k];
        for (int i = 0; i < k; ++i) {
            ret[i] = xors[queries[i][1] + 1] ^ xors[queries[i][0]];
        }
        return ret;
    }
}
// @lc code=end

