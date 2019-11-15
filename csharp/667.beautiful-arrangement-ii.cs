/*
 * @lc app=leetcode id=667 lang=csharp
 *
 * [667] Beautiful Arrangement II
 */

// @lc code=start
public class Solution {
    public int[] ConstructArray(int n, int k) {
        int left = 1, right = n;
        int[] ret = new int[n];
        --k;
        for (int i = 0; i < n; ++i) {
            if (k > 0) {
                ret[i] = k % 2 == 0 ? left++ : right--;
                --k;
            } else {
                ret[i] = left++;
            }
        }
        return ret;
    }
}
// @lc code=end

