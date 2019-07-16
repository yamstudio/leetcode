/*
 * @lc app=leetcode id=94 lang=csharp
 *
 * [94] Binary Tree Inorder Traversal
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
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> ret = new List<int>();
        IList<TreeNode> stack = new List<TreeNode>();
        TreeNode curr = root;
        while (stack.Count > 0 || curr != null) {
            if (curr == null) {
                curr = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                if (curr != null) {
                    ret.Add(curr.val);
                    curr = curr.right;
                }
            } else {
                stack.Add(curr);
                if (curr != null) {
                    curr = curr.left;
                }
            }
        }
        return ret;
    }
}

