/*
 * @lc app=leetcode id=450 lang=csharp
 *
 * [450] Delete Node in a BST
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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) {
            return null;
        }
        int val = root.val;
        if (key > val) {
            root.right = DeleteNode(root.right, key);
            return root;
        }
        if (key < val) {
            root.left = DeleteNode(root.left, key);
            return root;
        }
        if (root.left == null) {
            return root.right;
        }
        if (root.right == null) {
            return root.left;
        }
        TreeNode node = root.right;
        while (node.left != null) {
            node = node.left;
        }
        root.val = node.val;
        root.right = DeleteNode(root.right, root.val);
        return root;
    }
}

