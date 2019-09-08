/*
 * @lc app=leetcode id=387 lang=csharp
 *
 * [387] First Unique Character in a String
 */

using System.Linq;

public class Solution {
    public int FirstUniqChar(string s) {
        var chars = s.Select(c => (int) c - (int) 'a').ToArray();
        int[] count = new int[26];
        foreach (int c in chars) {
            ++count[c];
        }
        for (int i = 0; i < s.Length; ++i) {
            if (count[chars[i]] == 1) {
                return i;
            }
        }
        return -1;
    }
}

