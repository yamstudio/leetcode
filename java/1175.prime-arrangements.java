/*
 * @lc app=leetcode id=1175 lang=java
 *
 * [1175] Prime Arrangements
 */

import java.util.Collections;
import java.util.List;

// @lc code=start

class Solution {
    private static final List<Integer> PRIMES = List.of(
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
    );

    public int numPrimeArrangements(int n) {
        int p = Collections.binarySearch(PRIMES, n);
        if (p >= 0) {
            ++p;
        } else {
            p = - p - 1;
        }
        long ret = 1;
        for (int i = 2; i <= p; ++i) {
            ret = (ret * i) % 1000000007;
        }
        for (int i = n - p; i >= 2; --i) {
            ret = (ret * i) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

