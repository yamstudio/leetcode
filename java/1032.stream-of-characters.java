/*
 * @lc app=leetcode id=1032 lang=java
 *
 * [1032] Stream of Characters
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start
class StreamChecker {

    private final TrieNode root = new TrieNode();
    private TrieNode match;

    public StreamChecker(String[] words) {
        for (String word : words) {
            int n = word.length();
            TrieNode curr = root;
            for (int i = 0; i < n; ++i) {
                int c = word.charAt(i) - 'a';
                if (curr.children[c] == null) {
                    curr.children[c] = new TrieNode();
                }
                curr = curr.children[c];
            }
            curr.end = true;
        }
        Queue<TrieNode> queue = new ArrayDeque<>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            TrieNode curr = queue.poll();
            for (int i = 0; i < 26; ++i) {
                TrieNode child = curr.children[i];
                if (child == null) {
                    continue;
                }
                TrieNode lastMatch = curr.lastMatch;
                while (lastMatch != null && lastMatch.children[i] == null) {
                    lastMatch = lastMatch.lastMatch;
                }
                if (lastMatch == null) {
                    child.lastMatch = root;
                } else {
                    child.lastMatch = lastMatch.children[i];
                    child.end |= child.lastMatch.end;
                }
                queue.offer(child);
            }
        }
        root.lastMatch = root;
        match = root;
    }
    
    public boolean query(char letter) {
        int c = letter - 'a';
        while (match != root && match.children[c] == null) {
            match = match.lastMatch;
        }
        if (match.children[c] != null) {
            match = match.children[c];
        }
        return match.end;
    }

    private static class TrieNode {
        private final TrieNode[] children = new TrieNode[26];
        private boolean end = false;
        private TrieNode lastMatch;
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * boolean param_1 = obj.query(letter);
 */
// @lc code=end

