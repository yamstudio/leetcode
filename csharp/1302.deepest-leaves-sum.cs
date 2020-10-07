/*
 * @lc app=leetcode id=1302 lang=csharp
 *
 * [1302] Deepest Leaves Sum
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
    public int DeepestLeavesSum(TreeNode root) {
        var queue = new Queue<TreeNode>();
        int ret = 0;
        queue.Enqueue(root);
        while (queue.Count > 0) {
            ret = 0;
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                ret += curr.val;
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

