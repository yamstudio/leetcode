/*
 * @lc app=leetcode id=1008 lang=java
 *
 * [1008] Construct Binary Search Tree from Preorder Traversal
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    public TreeNode bstFromPreorder(int[] preorder) {
        TreeNode s = new TreeNode(Integer.MAX_VALUE);
        helper(s, 0, preorder, Integer.MAX_VALUE);
        return s.left;
    }

    private static int helper(TreeNode pre, int i, int[] preorder, int max) {
        if (i >= preorder.length) {
            return i;
        }
        int val = preorder[i];
        if (val >= max) {
            return i;
        }
        int ri;
        if (val < pre.val) {
            TreeNode l = new TreeNode(val);
            pre.left = l;
            ri = helper(l, i + 1, preorder, pre.val);
        } else {
            ri = i;
        }
        if (ri >= preorder.length) {
            return ri;
        }
        int rval = preorder[ri];
        if (rval >= max) {
            return ri;
        }
        TreeNode r = new TreeNode(rval);
        pre.right = r;
        return helper(r, ri + 1, preorder, max);
    }
}
// @lc code=end

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() {}
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
