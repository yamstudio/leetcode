/*
 * @lc app=leetcode id=388 lang=csharp
 *
 * [388] Longest Absolute File Path
 */

using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Solution {
    public int LengthLongestPath(string input) {
        List<int> lengths = new List<int>();
        int ret = 0, length = -1;
        Regex regex = new Regex(@"[A-Za-z0-9]+\.[A-Za-z0-9]+");
        foreach (string dir in input.Split('\n')) {
            int count = 0;
            foreach (char c in dir) {
                if (c != '\t') {
                    break;
                }
                ++count;
            }
            int len = dir.Length - count + 1,  diff = lengths.Count - count;
            while (diff-- > 0) {
                int j = count + diff;
                length -= lengths[j];
                lengths.RemoveAt(j);;
            }
            lengths.Add(len);
            length += len;
            if (regex.Match(dir).Success) {
                ret = Math.Max(ret, length);
            }
        }
        return ret;
    }
}

