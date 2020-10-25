/*
 * @lc app=leetcode id=1373 lang=csharp
 *
 * [1373] Maximum Sum BST in Binary Tree
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

    private static (bool IsBst, int Sum, int? Min, int? Max) MaxSumBSTRecurse(TreeNode root, ref int ret) {
        if (root == null) {
            return (IsBst: true, Sum: 0, Min: null, Max: null);
        }
        var l = MaxSumBSTRecurse(root.left, ref ret);
        var r = MaxSumBSTRecurse(root.right, ref ret);
        if (l.IsBst && r.IsBst && (!l.Max.HasValue || l.Max.Value < root.val) && (!r.Min.HasValue || r.Min.Value > root.val)) {
            int sum = l.Sum + r.Sum + root.val;
            ret = Math.Max(ret, sum);
            return (IsBst: true, Sum: sum, Min: l.Min.HasValue ? l.Min.Value : root.val, Max: r.Max.HasValue ? r.Max.Value : root.val);
        }
        return (IsBst: false, Sum: -1, Min: null, Max: null);
    }

    public int MaxSumBST(TreeNode root) {
        int ret = 0;
        MaxSumBSTRecurse(root, ref ret);
        return ret;
    }
}
// @lc code=end

