/*
 * @lc app=leetcode id=828 lang=csharp
 *
 * [828] Unique Letter String
 */

// @lc code=start
public class Solution {
    public int UniqueLetterString(string S) {
        int ret = 0, n = S.Length, count = 0;
        int[] pp = new int[n], p = new int[n];
        for (int i = 0; i < n; ++i) {
            int c = (int)S[i] - (int)'A';
            count = (count + 1 + i - 2 * p[c] + pp[c]) % 1000000007;
            ret = (ret + count) % 1000000007;
            pp[c] = p[c];
            p[c] = i + 1;
        }
        return ret;
    }
}
// @lc code=end

