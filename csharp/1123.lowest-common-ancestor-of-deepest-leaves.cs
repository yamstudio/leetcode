/*
 * @lc app=leetcode id=1123 lang=csharp
 *
 * [1123] Lowest Common Ancestor of Deepest Leaves
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

    private static (int Depth, TreeNode Root) LcaDeepestLeavesRecurse(TreeNode root) {
        if (root == null) {
            return (Depth: 0, Root: null);
        }
        var l = LcaDeepestLeavesRecurse(root.left);
        var r = LcaDeepestLeavesRecurse(root.right);
        if (l.Depth > r.Depth) {
            return (Depth: l.Depth + 1, Root: l.Root);
        }
        if (r.Depth > l.Depth) {
            return (Depth: r.Depth + 1, Root: r.Root);
        }
        return (Depth: l.Depth + 1, Root: root);
    }

    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return LcaDeepestLeavesRecurse(root).Root;
    }
}
// @lc code=end

