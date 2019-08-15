/*
 * @lc app=leetcode id=226 lang=csharp
 *
 * [226] Invert Binary Tree
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
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if (root != null) {
            TreeNode left = root.left, right = root.right;
            root.right = InvertTree(left);
            root.left = InvertTree(right);
        }
        return root;
    }
}

