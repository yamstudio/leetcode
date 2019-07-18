/*
 * @lc app=leetcode id=101 lang=csharp
 *
 * [101] Symmetric Tree
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

    public bool AreSymmetric(TreeNode left, TreeNode right) {
        if (left == null) {
            return right == null;
        }
        if (right == null) {
            return false;
        }
        return left.val == right.val && AreSymmetric(left.left, right.right) && AreSymmetric(left.right, right.left);
    }

    public bool IsSymmetric(TreeNode root) {
        return root == null || AreSymmetric(root.left, root.right);
    }
}

