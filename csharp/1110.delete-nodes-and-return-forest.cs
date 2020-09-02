/*
 * @lc app=leetcode id=1110 lang=csharp
 *
 * [1110] Delete Nodes And Return Forest
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

    private static void DelNodesRecurse(TreeNode parent, TreeNode root, HashSet<int> values, IList<TreeNode> ret, bool isParentDeleted) {
        if (root == null) {
            return;
        }
        bool shouldDelete = values.Contains(root.val);
        if (shouldDelete) {
            if (parent.left == root) {
                parent.left = null;
            } else {
                parent.right = null;
            }
        } else if (isParentDeleted) {
            ret.Add(root);
        }
        DelNodesRecurse(root, root.left, values, ret, shouldDelete);
        DelNodesRecurse(root, root.right, values, ret, shouldDelete);
    }

    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        var ret = new List<TreeNode>();
        var values = new HashSet<int>(to_delete);
        var sentinel = new TreeNode(0);
        DelNodesRecurse(sentinel, root, values, ret, true);
        return ret;
    }
}
// @lc code=end

