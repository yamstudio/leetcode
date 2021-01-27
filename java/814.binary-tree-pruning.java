/*
 * @lc app=leetcode id=814 lang=java
 *
 * [814] Binary Tree Pruning
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {

    private static boolean pruneTreeRecurse(TreeNode root) {
        if (root == null) {
            return false;
        }
        boolean l = pruneTreeRecurse(root.left), r = pruneTreeRecurse(root.right);
        if (!l) {
            root.left = null;
        }
        if (!r) {
            root.right = null;
        }
        return l || r || root.val == 1;
    }

    public TreeNode pruneTree(TreeNode root) {
        return pruneTreeRecurse(root) ? root : null;
    }
}
// @lc code=end

