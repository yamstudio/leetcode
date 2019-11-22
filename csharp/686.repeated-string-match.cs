/*
 * @lc app=leetcode id=686 lang=csharp
 *
 * [686] Repeated String Match
 */

// @lc code=start
public class Solution {
    public int RepeatedStringMatch(string A, string B) {
        int m = A.Length, n = B.Length;
        for (int i = 0; i < m; ++i) {
            int j;
            for (j = 0; j < n && B[j] == A[(i + j) % m]; ++j);
            if (j == n) {
                return 1 + (i + j - 1) / m;
            }
        }
        return -1;
    }
}
// @lc code=end

