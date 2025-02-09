/*
 * @lc app=leetcode id=1339 lang=java
 *
 * [1339] Maximum Product of Splitted Binary Tree
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
    public int maxProduct(TreeNode root) {
        int sum = sum(root), h = sum / 2, d = getMinDiff(root, h);
        return (int)(((long)(h + d) * (long)(sum - h - d)) % 1000000007);
    }

    private static int sum(TreeNode root) {
        if (root == null) {
            return 0;
        }
        root.val += sum(root.left) + sum(root.right);
        return root.val;
    }

    private static int getMinDiff(TreeNode root, int t) {
        if (root == null) {
            return Integer.MAX_VALUE;
        }
        if (root.val <= t) {
            return root.val - t;
        }
        int ret = root.val - t, l = getMinDiff(root.left, t), r = getMinDiff(root.right, t);
        if (Math.abs(l) < ret) {
            ret = l;
        }
        if (Math.abs(r) < Math.abs(ret)) {
            ret = r;
        }
        return ret;
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
