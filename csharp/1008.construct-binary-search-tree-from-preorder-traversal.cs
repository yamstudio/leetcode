/*
 * @lc app=leetcode id=1008 lang=csharp
 *
 * [1008] Construct Binary Search Tree from Preorder Traversal
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

    private static TreeNode BstFromPreorderRecurse(int[] preorder, ref int i, int max) {
        if (i >= preorder.Length) {
            return null;
        }
        int v = preorder[i];
        if (v > max) {
            return null;
        }
        ++i;
        var ret = new TreeNode(v);
        ret.left = BstFromPreorderRecurse(preorder, ref i, v);
        ret.right = BstFromPreorderRecurse(preorder, ref i, max);
        return ret;
    }

    public TreeNode BstFromPreorder(int[] preorder) {
        int i = 0;
        return BstFromPreorderRecurse(preorder, ref i, int.MaxValue);
    }
}
// @lc code=end

