/*
 * @lc app=leetcode id=513 lang=csharp
 *
 * [513] Find Bottom Left Tree Value
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
    public int FindBottomLeftValue(TreeNode root) {
        int ret = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int n = queue.Count;
            ret = queue.Peek().val;
            while (n-- > 0) {
                var curr = queue.Dequeue();
                if (curr.left != null) {
                    queue.Enqueue(curr.left);
                }
                if (curr.right != null) {
                    queue.Enqueue(curr.right);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

