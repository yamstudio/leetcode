/*
 * @lc app=leetcode id=14 lang=csharp
 *
 * [14] Longest Common Prefix
 */
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        int i = 0;
        if (strs.Length == 0) {
            return "";
        } else if (strs.Length == 1) {
            return strs[0];
        }
        while (i < strs[0].Length) {
            char c = strs[0][i];
            bool match = true;
            for (int j = 1; j < strs.Length; ++j) {
                if (i >= strs[j].Length || strs[j][i] != c) {
                    match = false;
                    break;
                }
            }
            if (match) {
                ++i;
            } else {
                break;
            }
        }
        return strs[0].Substring(0, i);
    }
}

