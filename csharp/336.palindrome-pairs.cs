/*
 * @lc app=leetcode id=336 lang=csharp
 *
 * [336] Palindrome Pairs
 */

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {

    private static bool IsPalindrome(string word) {
        int left = 0, right = word.Length - 1;
        while (left < right) {
            if (word[left++] != word[right--]) {
                return false;
            }
        }
        return true;
    }

    public IList<IList<int>> PalindromePairs(string[] words) {
        int n = words.Length;
        ISet<int> lens = new HashSet<int>(n);
        IDictionary<string, int> map = new Dictionary<string, int>(n);
        IList<IList<int>> ret = new List<IList<int>>();
        for (int i = 0; i < n; ++i) {
            string word = words[i];
            map[word] = i;
            lens.Add(word.Length);
        }
        for (int i = 0; i < n; ++i) {
            string word = words[i];
            char[] wordArray = word.ToCharArray();
            Array.Reverse(wordArray);
            string rev = new string(wordArray);
            if (map.ContainsKey(rev) && rev != word) {
                ret.Add(new List<int> { i, map[rev] });
            }
            int m = word.Length;
            for (int len = 0; len < m; ++len) {
                if (!lens.Contains(len)) {
                    continue;
                }
                string suffix = new string(wordArray.Take(len).ToArray()), prefix = new string(wordArray.Skip(m - len).Take(len).ToArray());
                if (map.ContainsKey(prefix) && IsPalindrome($"{word}{prefix}")) {
                    ret.Add(new List<int> { i, map[prefix] });
                }
                if (map.ContainsKey(suffix) && IsPalindrome($"{suffix}{word}")) {
                    ret.Add(new List<int> { map[suffix], i });
                }
            }
        }
        return ret;
    }
}

