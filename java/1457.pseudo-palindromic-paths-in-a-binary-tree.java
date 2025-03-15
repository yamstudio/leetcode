/*
 * @lc app=leetcode id=1457 lang=java
 *
 * [1457] Pseudo-Palindromic Paths in a Binary Tree
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
    public int pseudoPalindromicPaths (TreeNode root) {
        return pseudoPalindromicPaths(root, 0);
    }

    private static int pseudoPalindromicPaths(TreeNode curr, int acc) {
        if (curr == null) {
            return 0;
        }
        acc ^= (1 << curr.val);
        if (curr.left == null && curr.right == null) {
            int c = 0;
            while (acc != 0) {
                c += acc & 1;
                acc >>= 1;
            }
            return c <= 1 ? 1 : 0;
        }
        return pseudoPalindromicPaths(curr.left, acc) + pseudoPalindromicPaths(curr.right, acc);
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
