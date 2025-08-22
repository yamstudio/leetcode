/*
 * @lc app=leetcode id=1735 lang=java
 *
 * [1735] Count Ways to Make Array With Product
 */

// @lc code=start
class Solution {

    private static int[] PRIMES = new int [] {
        2, 3, 5, 7, 11, 13, 
        17, 19, 23, 29, 31, 37, 
        41, 43, 47, 53, 59, 61, 
        67, 71, 73, 79, 83, 89, 
        97,
    };
    private static int[][] COMBS = new int[10013][14];

    public int[] waysToFillArray(int[][] queries) {
        int l = queries.length;
        int[] ret = new int[l];
        for (int i = 0; i < l; ++i) {
            int n = queries[i][0], k = queries[i][1];
            long c = 1;
            for (int fac : PRIMES) {
                int p = 0;
                while (k % fac == 0) {
                    ++p;
                    k /= fac;
                }
                c = (c * (long)COMBS[n - 1 + p][p]) % 1000000007;
            }
            if (k > 1) {
                c = (c * (long)n) % 1000000007;
            }
            ret[i] = (int)c;
        }
        return ret;
    }

    static {
        COMBS[0][0] = 1;
        for (int t = 1; t < 10013; ++t) {
            COMBS[t][0] = 1;
            for (int k = 1; k < 14; ++k) {
                COMBS[t][k] = (COMBS[t - 1][k] + COMBS[t - 1][k - 1]) % 1000000007;
            }
        }
    }
}
// @lc code=end

