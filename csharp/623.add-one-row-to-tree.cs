/*
 * @lc app=leetcode id=623 lang=csharp
 *
 * [623] Add One Row to Tree
 */

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
    public TreeNode AddOneRow(TreeNode root, int v, int d) {
        if (d == 1) {
            var ret = new TreeNode(v);
            ret.left = root;
            return ret;
        }
        if (root == null) {
            return null;
        }
        if (d == 2) {
            var left = new TreeNode(v);
            var right = new TreeNode(v);
            left.left = root.left;
            right.right = root.right;
            root.left = left;
            root.right = right;
        } else {
            AddOneRow(root.left, v, d - 1);
            AddOneRow(root.right, v, d - 1);
        }
        return root;
    }
}
// @lc code=end

