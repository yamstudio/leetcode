/*
 * @lc app=leetcode id=543 lang=csharp
 *
 * [543] Diameter of Binary Tree
 */

// @lc code=start
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

    private (int, int) DiameterOfBinaryTreeRecurse(TreeNode root, int ret) {
        if (root == null) {
            return (ret, -1);
        }
        var left = DiameterOfBinaryTreeRecurse(root.left, ret);
        var right = DiameterOfBinaryTreeRecurse(root.right, ret);
        return (Math.Max(Math.Max(left.Item1, right.Item1), left.Item2 + right.Item2 + 2), Math.Max(left.Item2, right.Item2) + 1);
    }

    public int DiameterOfBinaryTree(TreeNode root) {
        return DiameterOfBinaryTreeRecurse(root, 0).Item1;
    }
}
// @lc code=end

