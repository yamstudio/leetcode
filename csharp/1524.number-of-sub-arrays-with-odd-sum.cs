/*
 * @lc app=leetcode id=1524 lang=csharp
 *
 * [1524] Number of Sub-arrays With Odd Sum
 */

// @lc code=start
public class Solution {
    public int NumOfSubarrays(int[] arr) {
        int ret = 0, even = 0, odd = 0;
        foreach (int x in arr) {
            if (x % 2 == 0) {
                ++even;
            } else {
                int tmp = odd;
                odd = even + 1;
                even = tmp;
            }
            ret = (ret + odd) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

