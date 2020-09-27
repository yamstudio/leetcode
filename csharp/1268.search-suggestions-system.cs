/*
 * @lc app=leetcode id=1268 lang=csharp
 *
 * [1268] Search Suggestions System
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;

// @lc code=start
public class Solution {

    private class TrieNode {
        public TrieNode[] Children { get; }
        public bool IsWord { get; set; }

        public TrieNode() {
            Children = new TrieNode[26];
            IsWord = false;
        }
    }

    private static void Search(TrieNode root, StringBuilder stringBuilder, IList<string> ret) {
        if (root == null) {
            return;
        }
        if (ret.Count < 3 && root.IsWord) {
            ret.Add(stringBuilder.ToString());
        }
        for (int i = 0; i < 26 && ret.Count < 3; ++i) {
            if (root.Children[i] == null) {
                continue;
            }
            stringBuilder.Append((char)(i + (int)'a'));
            Search(root.Children[i], stringBuilder, ret);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
    }

    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        int n = searchWord.Length;
        TrieNode root = new TrieNode();
        var ret = new List<IList<string>>(n);
        var stringBuilder = new StringBuilder();
        foreach (var word in products.Where(w => w[0] == searchWord[0])) {
            var curr = root;
            foreach (char c in word) {
                int i = (int)c - (int)'a';
                TrieNode next = curr.Children[i];
                if (next == null) {
                    next = new TrieNode();
                    curr.Children[i] = next;
                }
                curr = next;
            }
            curr.IsWord = true;
        }
        foreach (char c in searchWord) {
            root = root.Children[(int)c - (int)'a'];
            if (root == null) {
                ret.AddRange(Enumerable.Repeat(new List<string>(), n - ret.Count));
                break;
            }
            stringBuilder.Append(c);
            var l = new List<string>(3);
            Search(root, stringBuilder, l);
            ret.Add(l);
        }
        return ret;
    }
}
// @lc code=end

