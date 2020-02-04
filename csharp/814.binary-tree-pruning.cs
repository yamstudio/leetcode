/*
 * @lc app=leetcode id=814 lang=csharp
 *
 * [814] Binary Tree Pruning
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
    public TreeNode PruneTree(TreeNode root) {
        if (root == null) {
            return null;
        }
        var l = PruneTree(root.left);
        var r = PruneTree(root.right);
        if (l == null && r == null && root.val == 0) {
            return null;
        }
        root.left = l;
        root.right = r;
        return root;
    }
}
// @lc code=end

