/*
 * @lc app=leetcode id=1028 lang=csharp
 *
 * [1028] Recover a Tree From Preorder Traversal
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private static IEnumerable<(int Level, TreeNode Node)> SplitString(string S) {
        int n = S.Length;
        for (int i = 0; i < n;) {
            int j = i, level, val = 0;
            while (S[j] == '-') {
                ++j;
            }
            level = j - i;
            while (j < n && S[j] != '-') {
                val = val * 10 + (int)S[j] - (int)'0';
                ++j;
            }
            i = j;
            yield return (Level: level, Node: new TreeNode(val));
        }
    }

    public TreeNode RecoverFromPreorder(string S) {
        var stack = new Stack<(int Level, TreeNode Node)>();
        foreach (var curr in SplitString(S)) {
            if (!stack.Any()) {
                stack.Push(curr);
                continue;
            }
            while (stack.Peek().Level != curr.Level - 1) {
                stack.Pop();
            }
            var parent = stack.Peek();
            if (parent.Node.left == null) {
                parent.Node.left = curr.Node;
            } else {
                parent.Node.right = curr.Node;
            }
            stack.Push(curr);
        }
        while (stack.Count > 1) {
            stack.Pop();
        }
        return stack.Pop().Node;
    }
}
// @lc code=end

