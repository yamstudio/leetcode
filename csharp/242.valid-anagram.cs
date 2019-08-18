/*
 * @lc app=leetcode id=242 lang=csharp
 *
 * [242] Valid Anagram
 */

using System.Linq;

public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }
        int[] count = new int[26];
        foreach (int i in s.Select(c => (int) (c - 'a'))) {
            ++count[i];
        }
        foreach (int i in t.Select(c => (int) (c - 'a'))) {
            --count[i];
            if (count[i] < 0) {
                return false;
            }
        }
        return true;
    }
}

