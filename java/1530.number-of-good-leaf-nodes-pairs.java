/*
 * @lc app=leetcode id=1530 lang=java
 *
 * [1530] Number of Good Leaf Nodes Pairs
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

    private static final int[] EMPTY = new int[10];

    public int countPairs(TreeNode root, int distance) {
        return helper(root, distance).count();
    }

    private static Pair helper(TreeNode root, int distance) {
        if (root == null) {
            return new Pair(0, EMPTY);
        }
        Pair l = helper(root.left, distance), r = helper(root.right, distance);
        int[] children = new int[distance];
        int count = l.count() + r.count(), lacc = 0;
        if (root.left == null && root.right == null) {
            children[0] = 1;
        }
        for (int i = 1; i < distance; ++i) {
            children[i] = l.children()[i - 1] + r.children()[i - 1];
            lacc += l.children()[i - 1];
            count += r.children()[distance - 1 - i] * lacc;
        }
        return new Pair(count, children);
    }

    private record Pair(int count, int[] children) {}
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
