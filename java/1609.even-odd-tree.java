/*
 * @lc app=leetcode id=1609 lang=java
 *
 * [1609] Even Odd Tree
 */

import java.util.ArrayDeque;
import java.util.Queue;

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
    public boolean isEvenOddTree(TreeNode root) {
        Queue<Pair> queue = new ArrayDeque<>();
        int level = -1, prev = -1;
        queue.offer(new Pair(0, root));
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            TreeNode node = curr.node();
            if (node == null) {
                continue;
            }
            if (level == curr.level()) {
                if ((level % 2 == 0 && node.val <= prev) || (level % 2 == 1 && node.val >= prev)) {
                    return false;
                }
            }
            level = curr.level();
            prev = node.val;
            if (level % 2 == prev % 2) {
                return false;
            }
            queue.offer(new Pair(level + 1, node.left));
            queue.offer(new Pair(level + 1, node.right));
        }
        return true;
    }

    private record Pair(int level, TreeNode node) {}
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