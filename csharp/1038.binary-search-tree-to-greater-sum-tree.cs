/*
 * @lc app=leetcode id=1038 lang=csharp
 *
 * [1038] Binary Search Tree to Greater Sum Tree
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

    private static void BstToGstRecurse(TreeNode root, ref int acc) {
        if (root == null) {
            return;
        }
        BstToGstRecurse(root.right, ref acc);
        acc += root.val;
        root.val = acc;
        BstToGstRecurse(root.left, ref acc);
    }

    public TreeNode BstToGst(TreeNode root) {
        int acc = 0;
        BstToGstRecurse(root, ref acc);
        return root;
    }
}
// @lc code=end

