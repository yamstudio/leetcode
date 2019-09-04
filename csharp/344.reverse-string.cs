/*
 * @lc app=leetcode id=344 lang=csharp
 *
 * [344] Reverse String
 */
public class Solution {
    public void ReverseString(char[] s) {
        int l = 0, r = s.Length - 1;
        while (l < r) {
            char t = s[l];
            s[l++] = s[r];
            s[r--] = t;
        }
    }
}

