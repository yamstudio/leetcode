/*
 * @lc app=leetcode id=979 lang=csharp
 *
 * [979] Distribute Coins in Binary Tree
 */

using System;

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

    private static (int Total, int Delta) DistributeCoinsRecurse(TreeNode root) {
        if (root == null) {
            return (Total: 0, Delta: 0);
        }
        var l = DistributeCoinsRecurse(root.left);
        var r = DistributeCoinsRecurse(root.right);
        return (Total: l.Total + r.Total + Math.Abs(l.Delta) + Math.Abs(r.Delta), Delta: l.Delta + r.Delta + root.val - 1);
    }

    public int DistributeCoins(TreeNode root) {
        return DistributeCoinsRecurse(root).Total;
    }
}
// @lc code=end

