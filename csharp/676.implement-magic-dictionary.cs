/*
 * @lc app=leetcode id=676 lang=csharp
 *
 * [676] Implement Magic Dictionary
 */

using System.Collections.Generic;

// @lc code=start
public class MagicDictionary {

    private IDictionary<int, IList<string>> Map;

    /** Initialize your data structure here. */
    public MagicDictionary() {
        Map = new Dictionary<int, IList<string>>();
    }
    
    /** Build a dictionary through a list of words */
    public void BuildDict(string[] dict) {
        foreach (var word in dict) {
            IList<string> list;
            int len = word.Length;
            if (Map.TryGetValue(len, out list)) {
                list.Add(word);
            } else {
                list = new List<string>();
                list.Add(word);
                Map[len] = list;
            }
        }
    }
    
    /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
    public bool Search(string word) {
        IList<string> list;
        int len = word.Length;
        if (!Map.TryGetValue(len, out list)) {
            return false;
        }
        foreach (var next in list) {
            int diff = 0;
            for (int i = 0; i < len; ++i) {
                if (word[i] != next[i]) {
                    ++diff;
                }
                if (diff > 1) {
                    break;
                }
            }
            if (diff == 1) {
                return true;
            }
        }
        return false;
    }
}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dict);
 * bool param_2 = obj.Search(word);
 */
// @lc code=end

