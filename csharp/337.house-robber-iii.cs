/*
 * @lc app=leetcode id=337 lang=csharp
 *
 * [337] House Robber III
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

    private (int, int) RobRecurse(TreeNode root) {
        if (root == null) {
            return (0, 0);
        }
        var left = RobRecurse(root.left);
        var right = RobRecurse(root.right);
        int noRob = Math.Max(left.Item1, left.Item2) + Math.Max(right.Item1, right.Item2), rob = root.val + left.Item1 + right.Item1;
        return (noRob, rob);
    }

    public int Rob(TreeNode root) {
        var ret = RobRecurse(root);
        return Math.Max(ret.Item1, ret.Item2);
    }
}

