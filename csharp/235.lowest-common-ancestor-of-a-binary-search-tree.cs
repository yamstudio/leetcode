/*
 * @lc app=leetcode id=235 lang=csharp
 *
 * [235] Lowest Common Ancestor of a Binary Search Tree
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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        int min = Math.Min(p.val, q.val), max = Math.Max(p.val, q.val);
        while (true) {
            if (root.val > max) {
                root = root.left;
            } else if (root.val < min) {
                root = root.right;
            } else {
                return root;
            }
        }
        return null;
    }
}

