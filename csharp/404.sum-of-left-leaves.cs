/*
 * @lc app=leetcode id=404 lang=csharp
 *
 * [404] Sum of Left Leaves
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
    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) {
            return 0;
        }
        var left = root.left;
        int rval = SumOfLeftLeaves(root.right);
        if (left != null && left.left == null && left.right == null) {
            return rval + left.val;
        }
        return SumOfLeftLeaves(left) + rval;
    }
}

