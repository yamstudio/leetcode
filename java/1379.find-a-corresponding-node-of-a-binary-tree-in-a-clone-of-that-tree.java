/*
 * @lc app=leetcode id=1379 lang=java
 *
 * [1379] Find a Corresponding Node of a Binary Tree in a Clone of That Tree
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
 *     TreeNode(int x) { val = x; }
 * }
 */

class Solution {
    public final TreeNode getTargetCopy(final TreeNode original, final TreeNode cloned, final TreeNode target) {
        Queue<Pair> queue = new ArrayDeque<>();
        queue.offer(new Pair(original, cloned));
        while (!queue.isEmpty()) {
            var curr = queue.poll();
            if (curr.o() == null) {
                continue;
            }
            if (curr.o() == target) {
                return curr.c();
            }
            queue.offer(new Pair(curr.o().left, curr.c().left));
            queue.offer(new Pair(curr.o().right, curr.c().right));
        }
        throw new IllegalStateException();
    }

    private record Pair(TreeNode o, TreeNode c) {}
}
// @lc code=end

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode(int x) { val = x; }
}
