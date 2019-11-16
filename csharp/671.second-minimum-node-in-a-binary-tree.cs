/*
 * @lc app=leetcode id=671 lang=csharp
 *
 * [671] Second Minimum Node In a Binary Tree
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
    public int FindSecondMinimumValue(TreeNode root) {
        if (root == null) {
            return -1;
        }
        int m = -1, s = -1;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var curr = queue.Dequeue();
            int val = curr.val;
            if (val < m || m == -1) {
                s = m;
                m = val;
            } else if (val != m && (s == -1 || val < s)) {
                s = val;
            }
            if (curr.left != null) {
                queue.Enqueue(curr.left);
            }
            if (curr.right != null) {
                queue.Enqueue(curr.right);
            }
        }
        return s;
    }
}
// @lc code=end

