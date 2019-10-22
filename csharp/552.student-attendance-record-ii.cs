/*
 * @lc app=leetcode id=552 lang=csharp
 *
 * [552] Student Attendance Record II
 */

// @lc code=start
public class Solution {
    
    private const long N = 1000000007;
    
    public int CheckRecord(int n) {
        long[,] prev = new long[3, 2], curr = new long[3, 2];
        prev[0, 0] = 1;
        for (int i = 1; i <= n; ++i) {
            curr[0, 0] = (prev[0, 0] + prev[1, 0] % N + prev[2, 0]) % N;
            curr[1, 0] = prev[0, 0];
            curr[2, 0] = prev[1, 0];
            curr[0, 1] = (prev[0, 0] + prev[1, 0] + prev[2, 0] + prev[0, 1] + prev[1, 1] + prev[2, 1]) % N;
            curr[1, 1] = prev[0, 1];
            curr[2, 1] = prev[1, 1];
            var tmp = curr;
            curr = prev;
            prev = tmp;
        }
        return (int) ((prev[0, 0] + prev[0, 1] + prev[1, 0] + prev[1, 1] + prev[2, 0] + prev[2, 1]) % N);
    }
}
// @lc code=end

