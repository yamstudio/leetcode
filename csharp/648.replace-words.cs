/*
 * @lc app=leetcode id=648 lang=csharp
 *
 * [648] Replace Words
 */

using System.Linq;
using System.Text;

// @lc code=start
public class Solution {
    private class TrieNode {
        public bool end { get; set; }
        public TrieNode[] children { get; }

        public TrieNode() {
            end = false;
            children = new TrieNode[26];
        }
    }

    private class Trie {
        private TrieNode root;
        public Trie() {
            root = new TrieNode();
        }
        
        public void Insert(string word) {
            TrieNode curr = root;
            foreach (int i in word.Select(c => (int) c - (int) 'a')) {
                if (curr.children[i] == null) {
                    curr.children[i] = new TrieNode();
                }
                curr = curr.children[i];
            }
            curr.end = true;
        }
        
        public string Search(string word) {
            TrieNode curr = root;
            StringBuilder sb = new StringBuilder();
            foreach (char c in word) {
                curr = curr.children[(int) c - (int) 'a'];
                if (curr == null) {
                    return word;
                }
                sb.Append(c);
                if (curr.end) {
                    break;
                }
            }
            return sb.ToString();
        }
    }

    public string ReplaceWords(IList<string> dict, string sentence) {
        Trie trie = new Trie();
        foreach (string word in dict) {
            trie.Insert(word);
        }
        return string.Join(' ', sentence.Split(' ').Select(t => trie.Search(t)));
    }
}
// @lc code=end

