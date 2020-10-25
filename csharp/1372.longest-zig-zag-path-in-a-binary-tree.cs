/*
 * @lc app=leetcode id=1372 lang=csharp
 *
 * [1372] Longest ZigZag Path in a Binary Tree
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

    private static (int Left, int Right) LongestZigZagRecurse(TreeNode root, ref int ret) {
        if (root == null) {
            return (Left: -1, Right: -1);
        }
        var l = LongestZigZagRecurse(root.left, ref ret);
        var r = LongestZigZagRecurse(root.right, ref ret);
        ret = Math.Max(ret, Math.Max(l.Right, r.Left) + 1);
        return (Left: l.Right + 1, Right: r.Left + 1);
    }

    public int LongestZigZag(TreeNode root) {
        int ret = 0;
        LongestZigZagRecurse(root, ref ret);
        return ret;
    }
}
// @lc code=end

