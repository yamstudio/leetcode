/*
 * @lc app=leetcode id=974 lang=csharp
 *
 * [974] Subarray Sums Divisible by K
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int SubarraysDivByK(int[] A, int K) {
        int n = A.Length, sum = 0, ret = 0;
        var count = new Dictionary<int, int>();
        count[0] = 1;
        foreach (int num in A) {
            sum = ((sum + num) % K + K) % K;
            if (count.TryGetValue(sum, out int c)) {
                ret += c;
                count[sum] = c + 1;
            } else {
                count[sum] = 1;
            }
        }
        return ret;
    }
}
// @lc code=end

