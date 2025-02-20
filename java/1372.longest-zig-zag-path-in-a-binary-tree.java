/*
 * @lc app=leetcode id=1372 lang=java
 *
 * [1372] Longest ZigZag Path in a Binary Tree
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
    public int longestZigZag(TreeNode root) {
        return helper(root).max() - 1;
    }

    private static Pair helper(TreeNode root) {
        if (root == null) {
            return new Pair(0, 0, 0);
        }
        Pair l = helper(root.left), r = helper(root.right);
        return new Pair(1 + l.r(), 1 + r.l(), Math.max(1 + l.r(), Math.max(1 + r.l(), Math.max(l.max(), r.max()))));
    }

    private record Pair(int l, int r, int max) {}
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
