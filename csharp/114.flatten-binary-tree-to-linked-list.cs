/*
 * @lc app=leetcode id=114 lang=csharp
 *
 * [114] Flatten Binary Tree to Linked List
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

    private TreeNode FlattenRecursive(TreeNode root) {
        if (root == null) {
            return null;
        }
        if (root.left == null && root.right == null) {
            return root;
        }
        TreeNode left = root.left, right = root.right, leftTail = FlattenRecursive(left), rightTail = FlattenRecursive(right);
        if (leftTail != null) {
            root.left = null;
            root.right = left;
            leftTail.right = right;
        }
        return rightTail == null ? leftTail : rightTail;
    }

    public void Flatten(TreeNode root) {
        FlattenRecursive(root);
    }
}

