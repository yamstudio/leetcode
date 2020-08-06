/*
 * @lc app=leetcode id=995 lang=csharp
 *
 * [995] Minimum Number of K Consecutive Bit Flips
 */

// @lc code=start
public class Solution {
    public int MinKBitFlips(int[] A, int K) {
        int n = A.Length, flip = 0, ret = 0;
        var flipped = new int[n];
        for (int i = 0; i < n; ++i) {
            flip ^= flipped[i];
            if (A[i] == flip) {
                if (i + K > n) {
                    return -1;
                }
                if (i + K < n) {
                    flipped[i + K] = 1;
                }
                ++ret;
                flip ^= 1;
            }
        }
        return ret;
    }
}
// @lc code=end

