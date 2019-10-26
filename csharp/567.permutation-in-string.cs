/*
 * @lc app=leetcode id=567 lang=csharp
 *
 * [567] Permutation in String
 */

// @lc code=start
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int m = s1.Length, n = s2.Length, diff = m;
        int[] count = new int[26], curr = new int[26];
        foreach (char c in s1) {
            ++count[(int) c - (int) 'a'];
        }
        for (int i = 0; i < n; ++i) {
            int x = (int) s2[i] - (int) 'a';
            if (curr[x]++ < count[x]) {
                --diff;
            }
            if (i >= m) {
                int y = (int) s2[i - m] - (int) 'a';
                if (curr[y]-- <= count[y]) {
                    ++diff;
                }
            }
            if (diff == 0) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

