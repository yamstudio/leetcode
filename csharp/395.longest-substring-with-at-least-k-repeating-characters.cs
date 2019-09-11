/*
 * @lc app=leetcode id=395 lang=csharp
 *
 * [395] Longest Substring with At Least K Repeating Characters
 */

using System.Linq;

public class Solution {
    public int LongestSubstring(string s, int k) {
        int[] array = s.Select(c => (int) c - (int) 'a').ToArray();
        int i = 0, ret = 0, n = array.Length;
        while (i + k <= n) {
            int[] count = new int[26];
            int mask = 0, ni = 1 + i;
            for (int j = i; j < n; ++j) {
                int curr = array[j];
                ++count[curr];
                if (count[curr] >= k) {
                    mask &= ~(1 << curr);
                } else {
                    mask |= 1 << curr;
                }
                if (mask == 0) {
                    ret = Math.Max(ret, j - i + 1);
                    ni = j + 1;
                }
            }
            i = ni;
        }
        return ret;
    }
}

