/*
 * @lc app=leetcode id=145 lang=csharp
 *
 * [145] Binary Tree Postorder Traversal
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
    public IList<int> PostorderTraversal(TreeNode root) {
        var ret = new List<int>();
        if (root == null) {
            return ret;
        }
        var stack = new List<TreeNode>();
        stack.Add(root);
        TreeNode prev = root;
        while (stack.Count != 0) {
            TreeNode top = stack[stack.Count - 1];
            if ((top.left == null && top.right == null) || prev == top.left || prev == top.right) {
                ret.Add(top.val);
                stack.RemoveAt(stack.Count - 1);
                prev = top;
            } else {
                
                if (top.right != null) {
                    stack.Add(top.right);
                }
                if (top.left != null) {
                    stack.Add(top.left);
                }
            }
        }

        return ret;
    }
}

