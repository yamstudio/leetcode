/*
 * @lc app=leetcode id=988 lang=java
 *
 * [988] Smallest String Starting From Leaf
 */

// @lc code=start

import java.util.ArrayDeque;
import java.util.Queue;

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
    public String smallestFromLeaf(TreeNode root) {
        Queue<Pair> queue = new ArrayDeque<>();
        queue.add(new Pair("", root));
        String ret = null;
        while (!queue.isEmpty()) {
            Pair p = queue.poll();
            String s = "%c%s".formatted(p.curr.val + 'a', p. val);
            if (p.curr.left != null) {
                queue.add(new Pair(s, p.curr.left));
            }
            if (p.curr.right != null) {
                queue.add(new Pair(s, p.curr.right));
            }
            if (p.curr.left == null && p.curr.right == null) {
                if (ret == null || s.compareTo(ret) < 0) {
                    ret = s;
                }
            }
        }
        return ret;
    }

    private record Pair(String val, TreeNode curr) {}
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
