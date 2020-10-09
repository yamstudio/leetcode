/*
 * @lc app=leetcode id=1310 lang=csharp
 *
 * [1310] XOR Queries of a Subarray
 */

// @lc code=start
public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        int n = arr.Length, k = queries.Length;
        int[] xors = new int[n + 1], ret = new int[k];
        for (int i = 1; i <= n; ++i) {
            xors[i] = xors[i - 1] ^ arr[i - 1];
        }
        for (int i = 0; i < k; ++i) {
            int[] query = queries[i];
            ret[i] = xors[query[0]] ^ xors[query[1] + 1];
        }
        return ret;
    }
}
// @lc code=end

