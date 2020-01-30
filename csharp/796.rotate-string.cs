/*
 * @lc app=leetcode id=796 lang=csharp
 *
 * [796] Rotate String
 */

// @lc code=start
public class Solution {
    public bool RotateString(string A, string B) {
        int n = A.Length;
        if (B.Length != n) {
            return false;
        }
        if (n == 0) {
            return true;
        }
        for (int i = 0; i < n; ++i) {
            int j;
            for (j = 0; j < n && B[j] == A[(i + j) % n]; ++j);
            if (j == n) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

