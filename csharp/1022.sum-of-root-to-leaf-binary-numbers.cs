/*
 * @lc app=leetcode id=1022 lang=csharp
 *
 * [1022] Sum of Root To Leaf Binary Numbers
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

    private static int SumRootToLeafRecurse(TreeNode root, int curr) {
        if (root == null) {
            return 0;
        }
        int next = (curr << 1) | root.val;
        if (root.left == null && root.right == null) {
            return next;
        }
        return SumRootToLeafRecurse(root.left, next) + SumRootToLeafRecurse(root.right, next);
    }

    public int SumRootToLeaf(TreeNode root) {
        return SumRootToLeafRecurse(root, 0);
    }
}
// @lc code=end

