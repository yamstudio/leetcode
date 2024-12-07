/*
 * @lc app=leetcode id=993 lang=java
 *
 * [993] Cousins in Binary Tree
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
    public boolean isCousins(TreeNode root, int x, int y) {
        Pair px = null, py = null;
        Queue<Pair> queue = new ArrayDeque<>();
        queue.add(new Pair(0, -1, root));
        while (px == null || py == null) {
            Pair p = queue.poll();
            if (p.curr.val == x) {
                px = p;
            }
            if (p.curr.val == y) {
                py = p;
            }
            if (p.curr.left != null) {
                queue.add(new Pair(p.level + 1, p.curr.val, p.curr.left));
            }
            if (p.curr.right != null) {
                queue.add(new Pair(p.level + 1, p.curr.val, p.curr.right));
            }
        }
        return px.level == py.level && px.parent != py.parent;
    }

    private record Pair(int level, int parent, TreeNode curr) {}
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
