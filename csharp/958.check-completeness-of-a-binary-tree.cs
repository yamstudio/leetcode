/*
 * @lc app=leetcode id=958 lang=csharp
 *
 * [958] Check Completeness of a Binary Tree
 */

using System.Collections.Generic;
using System.Linq;

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
    public bool IsCompleteTree(TreeNode root) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            bool flag = false;
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                if (curr.left == null) {
                    flag = true;
                } else {
                    if (flag) {
                        return false;
                    }
                    queue.Enqueue(curr.left);
                }
                if (curr.right == null) {
                    flag = true;
                } else {
                    if (flag) {
                        return false;
                    }
                    queue.Enqueue(curr.right);
                }
            }
            if (flag) {
                break;
            }
        }
        return queue.All(node => node.left == null && node.right == null);
    }
}
// @lc code=end

