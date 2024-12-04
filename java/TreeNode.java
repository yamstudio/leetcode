/*
 * @lc app=leetcode id=979 lang=java
 *
 * [979] Distribute Coins in Binary Tree
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
    public int distributeCoins(TreeNode root) {
        return distributCoinsRecurse(root).moves;
    }

    private Pair distributCoinsRecurse(TreeNode root) {
        if (root == null) {
            return new Pair(0, 0);
        }
        var l = distributCoinsRecurse(root.left);
        var r = distributCoinsRecurse(root.right);
        return new Pair(l.moves + r.moves + Math.abs(l.delta) + Math.abs(r.delta), l.delta + r.delta + root.val - 1);
    }

    private record Pair(int moves, int delta) {}
}
// @lc code=end

public class TreeNode {
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
