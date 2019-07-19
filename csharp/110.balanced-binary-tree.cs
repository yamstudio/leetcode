/*
 * @lc app=leetcode id=110 lang=csharp
 *
 * [110] Balanced Binary Tree
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

    private int getDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }
        int left = getDepth(root.left);
        if (left < 0) {
            return -1;
        }
        int right = getDepth(root.right);
        if (right < 0) {
            return -1;
        }
        if (Math.Abs(right - left) > 1) {
            return -1;
        }
        return Math.Max(left, right) + 1;
    }

    public bool IsBalanced(TreeNode root) {
        return getDepth(root) >= 0;
    }
}

