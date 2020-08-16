/*
 * @lc app=leetcode id=1026 lang=csharp
 *
 * [1026] Maximum Difference Between Node and Ancestor
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

    private static int MaxAncestorDiffRecurse(TreeNode curr, int max, int min) {
        if (curr == null) {
            return 0;
        }
        int v = curr.val;
        if (v > max) {
            max = v;
        } else if (v < min) {
            min = v;
        }
        return Math.Max(Math.Abs(max - min), Math.Max(MaxAncestorDiffRecurse(curr.left, max, min), MaxAncestorDiffRecurse(curr.right, max, min)));
    }

    public int MaxAncestorDiff(TreeNode root) {
        return MaxAncestorDiffRecurse(root, root.val, root.val);
    }
}
// @lc code=end

