/*
 * @lc app=leetcode id=1161 lang=csharp
 *
 * [1161] Maximum Level Sum of a Binary Tree
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
    public int MaxLevelSum(TreeNode root) {
        var queue = new Queue<TreeNode>();
        int ret = -1, m = int.MinValue, l = 1;
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int acc = 0;
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                acc += curr.val;
                if (curr.left != null) {
                    queue.Enqueue(curr.left);
                }
                if (curr.right != null) {
                    queue.Enqueue(curr.right);
                }
            }
            if (acc > m) {
                ret = l;
                m = acc;
            }
            ++l;
        }
        return ret;
    }
}
// @lc code=end

