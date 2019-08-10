/*
 * @lc app=leetcode id=212 lang=csharp
 *
 * [212] Word Search II
 */

using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {

    private static readonly Func<char, int> toInt = c => (int) c - (int) 'a';
    private static readonly int[][] dirs = {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

    private class TrieNode {
        public string word { get; set; }
        public TrieNode[] children { get; }

        public TrieNode() {
            children = new TrieNode[26];
        }
    }

    private class Trie {
        public TrieNode root { get; }

        public Trie() {
            root = new TrieNode();
        }
        
        public void Insert(string word) {
            TrieNode curr = root;
            foreach (int i in word.Select(toInt)) {
                if (curr.children[i] == null) {
                    curr.children[i] = new TrieNode();
                }
                curr = curr.children[i];
            }
            curr.word = word;
        }
    }

    private void Search(TrieNode node, bool[,] visited, int[][] board, IList<string> ret, int m, int n, int i, int j) {
        if (node == null) {
            return;
        }
        if (node.word != null) {
            ret.Add(node.word);
            node.word = null;
        }
        visited[i, j] = true;
        foreach (int[] dir in dirs) {
            int ni = i + dir[0], nj = j + dir[1];
            if (ni < 0 || ni >= m || nj < 0 || nj >= n || visited[ni, nj]) {
                continue;
            }
            Search(node.children[board[ni][nj]], visited, board, ret, m, n, ni, nj);
        }
        visited[i, j] = false;
    }

    public IList<string> FindWords(char[][] board, string[] words) {
        int m = board.Length, n = board[0].Length;
        int[][] intBoard = board.Select(row => row.Select(toInt).ToArray()).ToArray();
        Trie trie = new Trie();
        TrieNode root = trie.root;
        IList<string> ret = new List<string>();
        foreach (string word in words) {
            trie.Insert(word);
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                Search(root.children[intBoard[i][j]], new bool[m, n], intBoard, ret, m, n, i, j);
            }
        }
        return ret;
    }
}

