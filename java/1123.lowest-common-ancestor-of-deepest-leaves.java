/*
 * @lc app=leetcode id=1123 lang=java
 *
 * [1123] Lowest Common Ancestor of Deepest Leaves
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
    public TreeNode lcaDeepestLeaves(TreeNode root) {
        return helper(root, 0).ancestor();
    }

    private static Pair helper(TreeNode root, int depth) {
        if (root.left == null) {
            if (root.right == null) {
                return new Pair(root, depth);
            }
            return helper(root.right, depth + 1);
        }
        if (root.right == null) {
            return helper(root.left, depth + 1);
        }
        Pair l = helper(root.left, depth + 1), r = helper(root.right, depth + 1);
        if (l.depth() == r.depth()) {
            return new Pair(root, l.depth());
        }
        if (l.depth() < r.depth()) {
            return r;
        }
        return l;
    }

    private record Pair(TreeNode ancestor, int depth) {}
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
