/*
 * @lc app=leetcode id=112 lang=csharp
 *
 * [112] Path Sum
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
    public bool HasPathSum(TreeNode root, int sum) {
        if (root == null) {
            return false;;
        }
        sum -= root.val;
        if (root.left == null) {
            return (root.right == null && sum == 0) || HasPathSum(root.right, sum);
        }
        if (root.right == null) {
            return HasPathSum(root.left, sum);
        }
        return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
    }
}

