/*
 * @lc app=leetcode id=865 lang=java
 *
 * [865] Smallest Subtree with all the Deepest Nodes
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

    private static class Tuple {
        public int depth;
        public TreeNode node;
        public Tuple(int depth, TreeNode node) {
            this.depth = depth;
            this.node = node;
        }
    }

    private static Tuple subtreeWithAllDeepestRecurse(TreeNode root) {
        if (root == null) {
            return new Tuple(0, null);
        }
        Tuple l = subtreeWithAllDeepestRecurse(root.left), r = subtreeWithAllDeepestRecurse(root.right);
        if (l.depth > r.depth) {
            return new Tuple(l.depth + 1, l.node);
        } else if (l.depth < r.depth) {
            return new Tuple(r.depth + 1, r.node);
        }
        return new Tuple(l.depth + 1, root);
    }

    public TreeNode subtreeWithAllDeepest(TreeNode root) {
        return subtreeWithAllDeepestRecurse(root).node;
    }
}
// @lc code=end

