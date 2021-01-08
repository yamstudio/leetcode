/*
 * @lc app=leetcode id=1680 lang=csharp
 *
 * [1680] Concatenation of Consecutive Binary Numbers
 */

// @lc code=start
public class Solution {
    public int ConcatenatedBinary(int n) {
        long ret = 0;
        for (int i = 1; i <= n; ++i) {
            int len = 0, t = i;
            while (t != 0) {
                ++len;
                t >>= 1;
            }
            ret = (((ret << len) % 1000000007) + i) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

