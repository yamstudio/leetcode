/*
 * @lc app=leetcode id=745 lang=csharp
 *
 * [745] Prefix and Suffix Search
 */

using System.Collections.Generic;

// @lc code=start
public class WordFilter {

    private IDictionary<string, int> Map;

    public WordFilter(string[] words) {
        Map = new Dictionary<string, int>();
        for (int i = 0; i < words.Length; ++i) {
            var word = words[i];
            int n = word.Length;
            string[] prefixes = new string[n + 1], suffixes = new string[n + 1];
            for (int j = 0; j <= n; ++j) {
                prefixes[j] = word.Substring(0, j);
                suffixes[j] = word.Substring(n - j);
            }
            foreach (var prefix in prefixes) {
                foreach (var suffix in suffixes) {
                    Map[$"{prefix}-{suffix}"] = i;
                }
            }
        }
    }
    
    public int F(string prefix, string suffix) {
        if (Map.TryGetValue($"{prefix}-{suffix}", out int ret)) {
            return ret;
        }
        return -1;
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */
// @lc code=end

