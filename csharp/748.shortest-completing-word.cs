/*
 * @lc app=leetcode id=748 lang=csharp
 *
 * [748] Shortest Completing Word
 */

// @lc code=start
public class Solution {
    public string ShortestCompletingWord(string licensePlate, string[] words) {
        int[] p = new int[26];
        int n = 0;
        foreach (char c in licensePlate) {
            if (c >= 'A' && c <= 'Z') {
                ++n;
                ++p[(int) c - (int) 'A'];
            } else if (c >= 'a' && c <= 'z') {
                ++n;
                ++p[(int) c - (int) 'a'];
            }
        }
        string ret = null;
        foreach (string s in words) {
            if (s.Length < n || (ret != null && ret.Length <= s.Length)) {
                continue;
            }
            int[] pp = new int[26];
            int m = 0;
            foreach (char c in s) {
                if (c >= 'A' && c <= 'Z' && p[(int) c - (int) 'A'] > pp[(int) c - (int) 'A']) {
                    ++m;
                    ++pp[(int) c - (int) 'A'];
                } else if (c >= 'a' && c <= 'z' && p[(int) c - (int) 'a'] > pp[(int) c - (int) 'a']) {
                    ++m;
                    ++pp[(int) c - (int) 'a'];
                }
                if (m == n) {
                    ret = s;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

