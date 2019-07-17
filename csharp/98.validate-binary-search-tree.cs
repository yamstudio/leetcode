/*
 * @lc app=leetcode id=98 lang=csharp
 *
 * [98] Validate Binary Search Tree
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

    private bool IsValidBSTSubtree(TreeNode root, long min, long max) {
        if (root == null) {
            return true;
        }
        long val = (long) root.val;
        if (val <= min || val >= max) {
            return false;
        }
        if (!IsValidBSTSubtree(root.left, min, val)) {
            return false;
        }
        if (!IsValidBSTSubtree(root.right, val, max)) {
            return false;
        }
        return true;
    }

    public bool IsValidBST(TreeNode root) {
        return IsValidBSTSubtree(root, long.MinValue, long.MaxValue);
    }
}

