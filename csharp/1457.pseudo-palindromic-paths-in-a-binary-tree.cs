/*
 * @lc app=leetcode id=1457 lang=csharp
 *
 * [1457] Pseudo-Palindromic Paths in a Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private static int PseudoPalindromicPaths(TreeNode root, int state, int count) {
        if (root == null) {
            return 0;
        }
        int m = 1 << root.val;
        state ^= m;
        if ((state & m) == 0) {
            --count;
        } else {
            ++count;
        }
        if (root.left == null && root.right == null) {
            return count <= 1 ? 1 : 0;
        }
        return PseudoPalindromicPaths(root.left, state, count) + PseudoPalindromicPaths(root.right, state, count);
    }

    public int PseudoPalindromicPaths (TreeNode root) {
        return PseudoPalindromicPaths(root, 0, 0);
    }
}
// @lc code=end

