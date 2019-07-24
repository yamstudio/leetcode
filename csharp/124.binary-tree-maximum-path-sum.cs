/*
 * @lc app=leetcode id=124 lang=csharp
 *
 * [124] Binary Tree Maximum Path Sum
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

    int ret;

    private int MaxPathSumRecurse(TreeNode root) {
        if (root == null) {
            return 0;
        }
        int left = Math.Max(0, MaxPathSumRecurse(root.left)), right = Math.Max(MaxPathSumRecurse(root.right), 0);
        ret = Math.Max(ret, left + right + root.val);
        return root.val + Math.Max(left, right);
    }

    public int MaxPathSum(TreeNode root) {
        ret = root.val;
        MaxPathSumRecurse(root);
        return ret;
    }
}

