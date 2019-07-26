/*
 * @lc app=leetcode id=131 lang=csharp
 *
 * [131] Palindrome Partitioning
 */

using System.Collections.Generic;

public class Solution {

    private void PartitionDFS(string s, IList<IList<string>> ret, bool[,] isPalindrome, int i, int n, IList<string> curr) {
        if (i == n) {
            ret.Add(new List<string>(curr));
        }
        for (int j = i; j < n; ++j) {
            if (!isPalindrome[i, j]) {
                continue;
            }
            curr.Add(s.Substring(i, j - i + 1));
            PartitionDFS(s, ret, isPalindrome, j + 1, n, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public IList<IList<string>> Partition(string s) {
        var ret = new List<IList<string>>();
        int n = s.Length;
        if (n == 0) {
            return ret;
        }
        bool[,] isPalindrome = new bool[n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (s[i] == s[j] && (j >= i - 2 || isPalindrome[j + 1, i - 1])) {
                    isPalindrome[j, i] = true;
                }
            }
        }
        PartitionDFS(s, ret, isPalindrome, 0, n, new List<string>());
        return ret;
    }
}

