/*
 * @lc app=leetcode id=5 lang=csharp
 *
 * [5] Longest Palindromic Substring
 */
public class Solution {
    public string LongestPalindrome(string s) {
        char[] ns = new char[2 * (s.Length + 1)];
        int retCenter = 0, retRadius = 0, maxCenter = 0, maxRight = 0;
        int[] radii = new int[2 * (s.Length + 1)];
        ns[0] = '^';
        ns[1] = '|';
        for (int i = 0; i < s.Length; ++i) {
            ns[2 * i + 2] = s[i];
            ns[2 * i + 3] = '|';
        }
        radii[0] = 1;
        for (int i = 1; i < ns.Length; ++i) {
            if (maxRight > i) {
                radii[i] = Math.Min(radii[2 * maxCenter - i], maxRight - i);
            } else {
                radii[i] = 1;
            }

            while (i + radii[i] < ns.Length && ns[i + radii[i]] == ns[i - radii[i]]) {
                radii[i] += 1;
            }

            if (radii[i] + i > maxRight) {
                maxCenter = i;
                maxRight = radii[i] + i;
            }

            if (radii[i] > retRadius) {
                retCenter = i;
                retRadius = radii[i];
            }
        }

        return s.Substring((retCenter - retRadius) / 2, retRadius - 1);
    }
}

