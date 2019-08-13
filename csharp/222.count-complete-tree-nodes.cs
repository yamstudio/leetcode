/*
 * @lc app=leetcode id=222 lang=csharp
 *
 * [222] Count Complete Tree Nodes
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
    public int CountNodes(TreeNode root) {
        if (root == null) {
            return 0;
        }
        TreeNode node = root;
        int left = 0, right = 0, ret = 1;
        while (node != null) {
            node = node.left;
            ++left;
            ret *= 2;
        }
        while (node != null) {
            node = node.right;
            ++right;
        }
        if (left == right) {
            return ret - 1;
        }
        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }
}

