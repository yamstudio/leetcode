/*
 * @lc app=leetcode id=1080 lang=java
 *
 * [1080] Insufficient Nodes in Root to Leaf Paths
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
    public TreeNode sufficientSubset(TreeNode root, int limit) {
        TreeNode sentinel = new TreeNode(0);
        sentinel.left = root;
        prune(sentinel, 0, limit);
        return sentinel.left;
    }

    private static boolean prune(TreeNode root, int curr, int limit) {
        if (root.left == null && root.right == null) {
            return curr + root.val < limit;
        }
        boolean pruneLeft = root.left == null || prune(root.left, curr + root.val, limit);
        boolean pruneRight = root.right == null || prune(root.right, curr + root.val, limit);
        if (pruneLeft) {
            root.left = null;
        }
        if (pruneRight) {
            root.right = null;
        }
        return pruneLeft && pruneRight;
    }
}
// @lc code=end

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() {}
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
