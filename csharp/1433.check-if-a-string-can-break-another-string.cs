/*
 * @lc app=leetcode id=1433 lang=csharp
 *
 * [1433] Check If a String Can Break Another String
 */

// @lc code=start
public class Solution {
    public bool CheckIfCanBreak(string s1, string s2) {
        int n = s1.Length, s12 = 0, s21 = 0;
        int[] c1 = new int[26], c2 = new int[26];
        for (int i = 0; i < n; ++i) {
            ++c1[(int)s1[i] - (int)'a'];
            ++c2[(int)s2[i] - (int)'a'];
        }
        for (int i = 0; i < 26; ++i) {
            if (s12 >= 0) {
                s12 += c1[i] - c2[i];
            }
            if (s21 >= 0) {
                s21 += c2[i] - c1[i];
            }
        }
        return s12 >= 0 || s21 >= 0;
    }
}
// @lc code=end

