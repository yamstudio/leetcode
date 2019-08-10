/*
 * @lc app=leetcode id=211 lang=csharp
 *
 * [211] Add and Search Word - Data structure design
 */

using System.Collections.Generic;
using System.Linq;

public class WordDictionary {

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
    public WordDictionary() {
        root = new TrieNode();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        TrieNode curr = root;
        foreach (int i in word.Select(c => (int) c - (int) 'a')) {
            if (curr.children[i] == null) {
                curr.children[i] = new TrieNode();
            }
            curr = curr.children[i];
        }
        curr.end = true;
    }

    private bool Search(TrieNode curr, int[] word, int index) {
        if (curr == null) {
            return false;
        }
        if (index == word.Length) {
            return curr.end;
        }
        return (word[index] == (int ) '.' - (int) 'a' ? curr.children : new TrieNode[]{ curr.children[word[index]] }).Any(node => Search(node, word, index + 1));
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return Search(root, word.Select(c => (int) c - (int) 'a').ToArray(), 0);
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

