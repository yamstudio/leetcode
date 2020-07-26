/*
 * @lc app=leetcode id=965 lang=csharp
 *
 * [965] Univalued Binary Tree
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

    private static bool IsUnivalTreeRecurse(TreeNode root, int val) {
        return root == null || (root.val == val && IsUnivalTreeRecurse(root.left, val) && IsUnivalTreeRecurse(root.right, val));
    }

    public bool IsUnivalTree(TreeNode root) {
        return IsUnivalTreeRecurse(root, root.val);
    }
}
// @lc code=end

