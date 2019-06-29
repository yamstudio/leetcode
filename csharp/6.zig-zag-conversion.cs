/*
 * @lc app=leetcode id=6 lang=csharp
 *
 * [6] ZigZag Conversion
 */
public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) {
            return s;
        }
        int n = 2 * numRows - 2, count = 0;
        char[] ret = new char[s.Length];
        for (int i = 0; i < numRows; ++i) {
            for (int j = i; j < s.Length + n - 1; j += n) {
                if (j < s.Length) {
                    ret[count++] = s[j];
                }
                int k = j + n - 2 * i;
                if (i > 0 && i < numRows - 1 && k < s.Length) {
                    ret[count++] = s[k];
                }
            }
        }
        return new string(ret);
    }
}

