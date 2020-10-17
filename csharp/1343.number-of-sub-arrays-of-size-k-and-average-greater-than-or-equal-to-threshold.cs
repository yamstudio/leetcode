/*
 * @lc app=leetcode id=1343 lang=csharp
 *
 * [1343] Number of Sub-arrays of Size K and Average Greater than or Equal to Threshold
 */

// @lc code=start
public class Solution {
    public int NumOfSubarrays(int[] arr, int k, int threshold) {
        int l = 0, acc = 0, n = arr.Length, ret = 0;
        threshold *= k;
        for (int r = 0; r < n; ++r) {
            acc += arr[r];
            if (l + k == r) {
                acc -= arr[l++];
            }
            if (l + k == r + 1 && acc >= threshold) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

