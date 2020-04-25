/*
 * @lc app=leetcode id=897 lang=csharp
 *
 * [897] Increasing Order Search Tree
 */

using System.Collections.Generic;
using System.Linq;

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

    private static IEnumerable<TreeNode> DeconstructRecurse(TreeNode root) {
        if (root == null) {
            return Enumerable.Empty<TreeNode>();
        }
        var left = root.left;
        var right = root.right;
        root.left = null;
        root.right = null;
        return DeconstructRecurse(left)
            .Append(root)
            .Concat(DeconstructRecurse(right));
    }

    public TreeNode IncreasingBST(TreeNode root) {
        var ret = new TreeNode(0);
        var curr = ret;
        foreach (var node in DeconstructRecurse(root)) {
            curr.right = node;
            curr = node;
        }
        return ret.right;
    }
}
// @lc code=end

