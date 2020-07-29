/*
 * @lc app=leetcode id=971 lang=csharp
 *
 * [971] Flip Binary Tree To Match Preorder Traversal
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
    
    private static int FlipMatchVoyageRecurse(TreeNode root, int[] voyage, IList<int> ret, int i) {
        if (root == null) {
            return i;
        }
        if (i == -1) {
            return -1;
        }
        int val = root.val;
        if (val != voyage[i++]) {
            ret.Clear();
            ret.Add(-1);
            return -1;
        }
        if (i < voyage.Length && root.left != null && root.left.val != voyage[i]) {
            ret.Add(val);
            i = FlipMatchVoyageRecurse(root.right, voyage, ret, i);
            i = FlipMatchVoyageRecurse(root.left, voyage, ret, i);
        } else {
            i = FlipMatchVoyageRecurse(root.left, voyage, ret, i);
            i = FlipMatchVoyageRecurse(root.right, voyage, ret, i);
        }
        return i;
    }
    
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage) {
        var ret = new List<int>();
        FlipMatchVoyageRecurse(root, voyage, ret, 0);
        return ret;
    }
}
// @lc code=end

