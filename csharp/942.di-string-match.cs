/*
 * @lc app=leetcode id=942 lang=csharp
 *
 * [942] DI String Match
 */

// @lc code=start
public class Solution {
    public int[] DiStringMatch(string S) {
        int n = S.Length, l = 0, r = n;
        int[] ret = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            if (S[i] == 'I') {
                ret[i] = l++;
            } else {
                ret[i] = r--;
            }
        }
        ret[n] = r;
        return ret;
    }
}
// @lc code=end

