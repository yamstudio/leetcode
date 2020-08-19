/*
 * @lc app=leetcode id=1032 lang=csharp
 *
 * [1032] Stream of Characters
 */

using System.Collections.Generic;

// @lc code=start
public class StreamChecker {

    private TrieNode Root, Now;

    public StreamChecker(string[] words) {
        Root = new TrieNode();
        foreach (var word in words) {
            var curr = Root;
            foreach (var c in word) {
                int i = (int)c - (int)'a';
                if (curr.Children[i] == null) {
                    curr.Children[i] = new TrieNode();
                }
                curr = curr.Children[i];
            }
            curr.IsEnd = true;
        }
        var queue = new Queue<TrieNode>();
        queue.Enqueue(Root);
        while (queue.TryDequeue(out var curr)) {
            for (int i = 0; i < 26; ++i) {
                var next = curr.Children[i];
                if (next == null) {
                    continue;
                }
                var fail = curr.Fail;
                while (fail != null && fail.Children[i] == null) {
                    fail = fail.Fail;
                }
                if (fail == null) {
                    next.Fail = Root;
                } else {
                    next.Fail = fail.Children[i];
                    next.IsEnd |= fail.Children[i].IsEnd;
                }
                queue.Enqueue(next);
            }
        }
        Root.Fail = Root;
        Now = Root;
    }
    
    public bool Query(char letter) {
        int i = (int)letter - (int)'a';
        while (Now != Root && Now.Children[i] == null) {
            Now = Now.Fail;
        }
        if (Now.Children[i] != null) {
            Now = Now.Children[i];
        }
        return Now.IsEnd;
    }

    private class TrieNode {
        
        public TrieNode[] Children { get; }
        public TrieNode Fail { get; set; }
        public bool IsEnd { get; set; }
        
        public TrieNode() {
            Children = new TrieNode[26];
            Fail = null;
            IsEnd = false;
        }
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */
// @lc code=end

