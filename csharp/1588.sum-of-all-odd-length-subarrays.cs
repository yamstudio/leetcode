/*
 * @lc app=leetcode id=1588 lang=csharp
 *
 * [1588] Sum of All Odd Length Subarrays
 */

// @lc code=start
public class Solution {
    public int SumOddLengthSubarrays(int[] arr) {
        int ret = 0, n = arr.Length;
        for (int i = 0; i < n; ++i) {
            ret += ((i + 1) * (n - i) + 1) / 2 * arr[i];
        }
        return ret;
    }
}
// @lc code=end

