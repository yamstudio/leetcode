/*
 * @lc app=leetcode id=783 lang=csharp
 *
 * [783] Minimum Distance Between BST Nodes
 */

using System;

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

    private static bool MinDiffInBSTRecurse(TreeNode root, out int diff, out int min, out int max) {
        if (root == null) {
            diff = -1;
            min = int.MaxValue;
            max = int.MinValue;
            return false;
        }
        diff = int.MaxValue;
        min = root.val;
        max = min;
        if (MinDiffInBSTRecurse(root.left, out int ldiff, out int lmin, out int lmax)) {
            diff = Math.Min(ldiff, root.val - lmax);
            min = lmin;
        }
        if (MinDiffInBSTRecurse(root.right, out int rdiff, out int rmin, out int rmax)) {
            diff = Math.Min(diff, Math.Min(rdiff, rmin - root.val));
            max = rmax;
        }
        return true;
    }

    public int MinDiffInBST(TreeNode root) {
        if (MinDiffInBSTRecurse(root, out int diff, out int min, out int max)) {
            return diff;
        }
        return -1;
    }
}
// @lc code=end

