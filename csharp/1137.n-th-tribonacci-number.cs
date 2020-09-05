/*
 * @lc app=leetcode id=1137 lang=csharp
 *
 * [1137] N-th Tribonacci Number
 */

// @lc code=start
public class Solution {
    public int Tribonacci(int n) {
        int[] ret = new int[] { 0, 1, 1 };
        for (int i = 3; i <= n; ++i) {
            ret[i % 3] += ret[(i + 1) % 3] + ret[(i + 2) % 3];
        }
        return ret[n % 3];
    }
}
// @lc code=end

