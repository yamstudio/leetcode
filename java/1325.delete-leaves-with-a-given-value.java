/*
 * @lc app=leetcode id=1325 lang=java
 *
 * [1325] Delete Leaves With a Given Value
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
    public TreeNode removeLeafNodes(TreeNode root, int target) {
        TreeNode sentinel = new TreeNode(-1, root, null);
        removeLeafNodesRecurse(sentinel, target);
        return sentinel.left;
    }

    private static boolean removeLeafNodesRecurse(TreeNode curr, int target) {
        if (curr == null) {
            return false;
        }
        if (removeLeafNodesRecurse(curr.left, target)) {
            curr.left = null;
        }
        if (removeLeafNodesRecurse(curr.right, target)) {
            curr.right = null;
        }
        return curr.val == target && curr.left == null && curr.right == null;
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
