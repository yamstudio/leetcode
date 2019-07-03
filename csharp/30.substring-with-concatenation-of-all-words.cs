/*
 * @lc app=leetcode id=30 lang=csharp
 *
 * [30] Substring with Concatenation of All Words
 */

using System.Collections.Generic;

public static class Ext {
    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value : defaultValue;
    }
}

public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        if (s.Length == 0 || words.Length ==  0) {
            return Array.Empty<int>();
        }
        IList<int> ret = new List<int>();
        Dictionary<string, int> wordCount = new Dictionary<string, int>(), currCount = new Dictionary<string, int>();
        int total = words.Length, len = words[0].Length;
        foreach (string word in words) {
            wordCount[word] = wordCount.GetOrDefault(word, 0) + 1;
        }
        for (int i = 0; i < len; ++i) {
            currCount.Clear();
            int left = i, count = 0;
            for (int j = i; j <= s.Length - len; j += len) {
                string word = s.Substring(j, len);
                if (!wordCount.ContainsKey(word)) {
                    currCount.Clear();
                    count = 0;
                    left = j + len;
                    continue;
                }
                currCount[word] = currCount.GetOrDefault(word, 0) + 1;
                if (currCount[word] <= wordCount[word]) {
                    ++count;
                } else {
                    while (currCount[word] > wordCount[word]) {
                        string prev = s.Substring(left, len);
                        if (--currCount[prev] < wordCount[prev]) {
                            --count;
                        }
                        left += len;
                    }
                }
                if (count == total) {
                    ret.Add(left);
                    --currCount[s.Substring(left, len)];
                    --count;
                    left += len;
                }
            }
        }
        return ret;
    }
}

