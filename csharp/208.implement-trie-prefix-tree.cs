/*
 * @lc app=leetcode id=208 lang=csharp
 *
 * [208] Implement Trie (Prefix Tree)
 */

using System.Linq;

public class Trie {

    private class TrieNode {
        public bool end { get; set; }
        public TrieNode[] children { get; }

        public TrieNode() {
            end = false;
            children = new TrieNode[26];
        }
    }

    private TrieNode root;

    /** Initialize your data structure here. */
    public Trie() {
        root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
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
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        TrieNode curr = root;
        foreach (int i in word.Select(c => (int) c - (int) 'a')) {
            curr = curr.children[i];
            if (curr == null) {
                return false;
            }
        }
        return curr.end;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        TrieNode curr = root;
        foreach (int i in prefix.Select(c => (int) c - (int) 'a')) {
            curr = curr.children[i];
            if (curr == null) {
                return false;
            }
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

