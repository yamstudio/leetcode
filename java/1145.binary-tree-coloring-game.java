/*
 * @lc app=leetcode id=1145 lang=java
 *
 * [1145] Binary Tree Coloring Game
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
    public boolean btreeGameWinningMove(TreeNode root, int n, int x) {
        int[] count = new int[] { 0, 0, 0 };
        helper(root, x, 0, count);
        int target = (n + 1) / 2;
        for (int c : count) {
            if (c >= target) {
                return true;
            }
        }
        return false;
    }

    private void helper(TreeNode curr, int x, int category, int[] count) {
        if (curr == null) {
            return;
        }
        if (category != 0 || curr.val != x) {
            ++count[category];
            helper(curr.left, x, category, count);
            helper(curr.right, x, category, count);
            return;
        }
        helper(curr.left, x, 1, count);
        helper(curr.right, x, 2, count);
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
