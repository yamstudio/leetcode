/*
 * @lc app=leetcode id=779 lang=csharp
 *
 * [779] K-th Symbol in Grammar
 */

// @lc code=start
public class Solution {
    public int KthGrammar(int N, int K) {
        if (N == 1) {
            return 0;
        }
        return (K % 2 == 0) ^ (KthGrammar(N - 1, (K + 1) / 2) == 0) ? 0 : 1;
    }
}
// @lc code=end

