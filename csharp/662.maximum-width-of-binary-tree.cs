/*
 * @lc app=leetcode id=662 lang=csharp
 *
 * [662] Maximum Width of Binary Tree
 */

using System.Collections.Generic;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int WidthOfBinaryTree(TreeNode root) {
        if (root == null) {
            return 0;
        }
        int ret = 1;
        Queue<(int, TreeNode)> queue = new Queue<(int, TreeNode)>();
        queue.Enqueue((1, root));
        while (queue.Count > 0) {
            int count = queue.Count, left = count == 1 ? 1 : queue.Peek().Item1, right = left;
            for (int i = 0; i < count; ++i) {
                var curr = queue.Dequeue();
                if (count > 1) {
                    right = curr.Item1;
                }
                TreeNode node = curr.Item2;
                if (node.left != null) {
                    queue.Enqueue((2 * right, node.left));
                }
                if (node.right != null) {
                    queue.Enqueue((2 * right + 1, node.right));
                }
            }
            ret = Math.Max(ret, right - left + 1);
        }
        return ret;
    }
}
// @lc code=end

