/*
 * @lc app=leetcode id=783 lang=java
 *
 * [783] Minimum Distance Between BST Nodes
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

    private static void addNodes(List<Integer> ret, TreeNode root) {
        if (root == null) {
            return;
        }
        addNodes(ret, root.left);
        ret.add(root.val);
        addNodes(ret, root.right);
    }

    public int minDiffInBST(TreeNode root) {
        List<Integer> values = new ArrayList<Integer>();
        addNodes(values, root);
        int n = values.size(), ret = Integer.MAX_VALUE;
        for (int i = 0; i < n - 1; ++i) {
            ret = Math.min(ret, values.get(i + 1) - values.get(i));
        }
        return ret;
    }
}
// @lc code=end

