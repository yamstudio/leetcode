/*
 * @lc app=leetcode id=443 lang=csharp
 *
 * [443] String Compression
 */
public class Solution {

    private static readonly int[] Tens = new int[]
    {
        1000, 100, 10, 1
    };

    public int Compress(char[] chars) {
        int n = chars.Length, l = 0, v = 0;
        for (int i = 0; i < n; ++i) {
            char c = chars[i];
            if (c != chars[l]) {
                chars[v++] = chars[l];
                if (i > l + 1) {
                    foreach (char x in (i - l).ToString()) {
                        chars[v++] = x;
                    }
                }
                l = i;
            }
        }
        chars[v++] = chars[l];
        if (n > l + 1) {
            foreach (char x in (n - l).ToString()) {
                chars[v++] = x;
            }
        }
        return v;
    }
}

