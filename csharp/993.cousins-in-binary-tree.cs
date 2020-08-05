/*
 * @lc app=leetcode id=993 lang=csharp
 *
 * [993] Cousins in Binary Tree
 */

using System.Collections.Generic;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsCousins(TreeNode root, int x, int y) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            bool hasVal = false;
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                if (curr.val == x || curr.val == y) {
                    if (hasVal) {
                        return true;
                    }
                    hasVal = true;
                }
                if (curr.left != null) {
                    if ((curr.left.val == x || curr.left.val == y) && (curr.right != null && (curr.right.val == x || curr.right.val == y))) {
                        return false;
                    }
                    queue.Enqueue(curr.left);
                }
                if (curr.right != null) {
                    queue.Enqueue(curr.right);
                }
            }
        }
        return false;
    }
}
// @lc code=end

