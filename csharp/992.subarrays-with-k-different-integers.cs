/*
 * @lc app=leetcode id=992 lang=csharp
 *
 * [992] Subarrays with K Different Integers
 */

// @lc code=start
public class Solution {

    private static int SubarraysWithKOrLess(int[] A, int K) {
        int l = 0, n = A.Length, c = 0, ret = 0;
        var count = new int[n + 1];
        for (int r = 0; r < n; ++r) {
            if (count[A[r]] == 0) {
                ++c;
            }
            ++count[A[r]];
            while (c > K) {
                if (count[A[l]] == 1) {
                    --c;
                }
                --count[A[l]];
                ++l;
            }
            ret += r - l + 1;
        }
        return ret;
    }

    public int SubarraysWithKDistinct(int[] A, int K) {
        return SubarraysWithKOrLess(A, K) - SubarraysWithKOrLess(A, K - 1);
    }
}
// @lc code=end

