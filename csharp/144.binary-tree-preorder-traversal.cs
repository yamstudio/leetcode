/*
 * @lc app=leetcode id=144 lang=csharp
 *
 * [144] Binary Tree Preorder Traversal
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        var ret = new List<int>();
        var stack = new List<TreeNode>();
        if (root == null) {
            return ret;
        }
        stack.Add(root);
        while (stack.Count != 0) {
            TreeNode curr = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            ret.Add(curr.val);
            if (curr.right != null) {
                stack.Add(curr.right);
            }
            if (curr.left != null) {
                stack.Add(curr.left);
            }
        }
        return ret;
    }
}

