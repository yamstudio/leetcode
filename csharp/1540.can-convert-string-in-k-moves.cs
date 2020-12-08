/*
 * @lc app=leetcode id=1540 lang=csharp
 *
 * [1540] Can Convert String in K Moves
 */

// @lc code=start
public class Solution {
    public bool CanConvertString(string s, string t, int k) {
        int n = s.Length;
        if (n != t.Length) {
            return false;
        }
        int[] changes = new int[27];
        for (int i = 0; i < n; ++i) {
            int d = (26 + t[i] - s[i]) % 26;
            if (d == 0) {
                continue;
            }
            if (changes[d]++ * 26 + d > k) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

