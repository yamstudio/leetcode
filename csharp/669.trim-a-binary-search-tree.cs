/*
 * @lc app=leetcode id=669 lang=csharp
 *
 * [669] Trim a Binary Search Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode TrimBST(TreeNode root, int L, int R) {
        if (root == null) {
            return null;
        }
        int val = root.val;
        if (val < L) {
            return TrimBST(root.right, L, R);
        }
        if (val > R) {
            return TrimBST(root.left, L, R);
        }
        root.left = TrimBST(root.left, L, R);
        root.right = TrimBST(root.right, L, R);
        return root;
    }
}
// @lc code=end

