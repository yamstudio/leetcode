/*
 * @lc app=leetcode id=434 lang=csharp
 *
 * [434] Number of Segments in a String
 */
public class Solution {
    public int CountSegments(string s) {
        int ret = 0;
        bool flag = false;
        foreach (char c in s) {
            if (c == ' ') {
                if (flag) {
                    ++ret;
                    flag = false;
                }
            } else {
                flag = true;
            }
        }
        if (flag) {
            ++ret;
        }
        return ret;
    }
}

