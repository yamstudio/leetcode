/*
 * @lc app=leetcode id=678 lang=csharp
 *
 * [678] Valid Parenthesis String
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool CheckValidString(string s) {
        IList<int> left = new List<int>(), star = new List<int>();
        int n = s.Length;
        for (int i = 0; i < n; ++i) {
            char c = s[i];
            if (c == '*') {
                star.Add(i);
            } else if (c == '(') {
                left.Add(i);
            } else {
                if (left.Count == 0) {
                    if (star.Count == 0) {
                        return false;
                    }
                    star.RemoveAt(star.Count - 1);
                } else {
                    left.RemoveAt(left.Count - 1);
                }
            }
        }
        int l = left.Count - 1, r = star.Count - 1;
        while (l >= 0 && r >= 0) {
            if (left[l] > star[r]) {
                return false;
            }
            --l;
            --r;
        }
        return l < 0;
    }
}
// @lc code=end

