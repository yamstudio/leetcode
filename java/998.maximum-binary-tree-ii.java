/*
 * @lc app=leetcode id=998 lang=java
 *
 * [998] Maximum Binary Tree II
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
    public TreeNode insertIntoMaxTree(TreeNode root, int val) {
        TreeNode max = new TreeNode(Integer.MAX_VALUE, null, root);
        helper(max, root, val);
        return max.right;
    }

    private static void helper(TreeNode parent, TreeNode curr, int val) {
        if (curr == null || curr.val < val) {
            parent.right = new TreeNode(val, curr, null);
        } else {
            helper(curr, curr.right, val);
        }
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
