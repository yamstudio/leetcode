/*
 * @lc app=leetcode id=1382 lang=java
 *
 * [1382] Balance a Binary Search Tree
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
    public TreeNode balanceBST(TreeNode root) {
        TreeNode sentinel = new TreeNode(Integer.MIN_VALUE);
        sentinel.right = root;
        int count = flatten(sentinel), height = (int)(Math.log(count + 1) / Math.log(2)), nodes = (int)Math.pow(2, height) - 1;
        createTree(sentinel, count - nodes);
        for (nodes = nodes / 2; nodes > 0; nodes /= 2) {
            createTree(sentinel, nodes);
        }
        return sentinel.right;
    }

    private static int flatten(TreeNode pp) {
        TreeNode p = pp.right;
        int ret = 0;
        while (p != null) {
            if (p.left == null) {
                ++ret;
                pp = p;
                p = p.right;
                continue;
            }
            TreeNode oldP = p;
            p = p.left;
            pp.right = p;
            oldP.left = p.right;
            p.right = oldP;
        }
        return ret;
    }

    private static void createTree(TreeNode pp, int nodes) {
        TreeNode p = pp.right;
        while (nodes-- > 0) {
            TreeNode oldP = p;
            p = p.right;
            pp.right = p;
            oldP.right = p.left;
            p.left = oldP;
            pp = p;
            p = p.right;
        }
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
