/*
 * @lc app=leetcode id=1382 lang=csharp
 *
 * [1382] Balance a Binary Search Tree
 */

using System.Collections.Generic;

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

    private static void Flatten(IList<TreeNode> nodes, TreeNode root) {
        if (root == null) {
            return;
        }
        Flatten(nodes, root.left);
        root.left = null;
        nodes.Add(root);
        Flatten(nodes, root.right);
        root.right = null;
    }

    private static TreeNode Build(IList<TreeNode> nodes, int l, int r) {
        if (l > r) {
            return null;
        }
        int m = (l + r) / 2;
        var ret = nodes[m];
        ret.left = Build(nodes, l, m - 1);
        ret.right = Build(nodes, m + 1, r);
        return ret;
    }

    public TreeNode BalanceBST(TreeNode root) {
        var nodes = new List<TreeNode>();
        Flatten(nodes, root);
        return Build(nodes, 0, nodes.Count - 1);
    }
}
// @lc code=end

