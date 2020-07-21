/*
 * @lc app=leetcode id=951 lang=csharp
 *
 * [951] Flip Equivalent Binary Trees
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
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        if (root1 == null) {
            return root2 == null;
        }
        if (root2 == null) {
            return false;
        }
        int v1 = root1.val, v2 = root2.val;
        return v1 == v2 && ((FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) || (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left)));
    }
}
// @lc code=end

