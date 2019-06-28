/*
 * @lc app=leetcode id=3 lang=csharp
 *
 * [3] Longest Substring Without Repeating Characters
 */

using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> set = new HashSet<char>();
        int ret = 0, left = 0;

        for (int i = 0; i < s.Length; ++i) {
            char curr = s[i];
            while (set.Contains(curr)) {
                set.Remove(s[left]);
                left += 1;
            }
            set.Add(curr);
            if (set.Count > ret) {
                ret = set.Count;
            }
        }

        return ret;
    }
}

