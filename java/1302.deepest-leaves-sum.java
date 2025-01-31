/*
 * @lc app=leetcode id=1302 lang=java
 *
 * [1302] Deepest Leaves Sum
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
    public int deepestLeavesSum(TreeNode root) {
        int[] ret = new int[] { 0, 0 };
        helper(root, 0, ret);
        return ret[1];
    }

    private void helper(TreeNode root, int level, int[] ret) {
        if (root == null) {
            return;
        }
        if (level > ret[0]) {
            ret[0] = level;
            ret[1] = root.val;
        } else if (level == ret[0]) {
            ret[1] += root.val;
        }
        helper(root.left, level + 1, ret);
        helper(root.right, level + 1, ret);
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
