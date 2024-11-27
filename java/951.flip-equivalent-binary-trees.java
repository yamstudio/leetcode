/*
 * @lc app=leetcode id=951 lang=java
 *
 * [951] Flip Equivalent Binary Trees
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
    public boolean flipEquiv(TreeNode root1, TreeNode root2) {
        if (root1 == null) {
            return root2 == null;
        }
        if (root2 == null) {
            return false;
        }
        if (root1.val != root2.val) {
            return false;
        }
        if (flipEquiv(root1.left, root2.left)) {
            return flipEquiv(root1.right, root2.right);
        }
        if (flipEquiv(root1.left, root2.right)) {
            return flipEquiv(root1.right, root2.left);
        }
        return false;
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
