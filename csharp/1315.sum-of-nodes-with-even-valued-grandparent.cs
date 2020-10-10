/*
 * @lc app=leetcode id=1315 lang=csharp
 *
 * [1315] Sum of Nodes with Even-Valued Grandparent
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

    private static int SumEvenGrandparent(int g, int p, TreeNode root) {
        if (root == null) {
            return 0;
        }
        return ((g + 1) % 2) * root.val + SumEvenGrandparent(p, root.val, root.left) + SumEvenGrandparent(p, root.val, root.right);
    }

    public int SumEvenGrandparent(TreeNode root) {
        return SumEvenGrandparent(-1, -1, root);
    }
}
// @lc code=end

