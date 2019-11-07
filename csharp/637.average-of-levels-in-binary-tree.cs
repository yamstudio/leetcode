/*
 * @lc app=leetcode id=637 lang=csharp
 *
 * [637] Average of Levels in Binary Tree
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
    public IList<double> AverageOfLevels(TreeNode root) {
        IList<double> ret = new List<double>();
        if (root == null) {
            return ret;
        }
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0) {
            int x = q.Count;
            double acc = 0;
            for (int i = 0; i < x; ++i) {
                var curr = q.Dequeue();
                acc += curr.val;
                if (curr.left != null) {
                    q.Enqueue(curr.left);
                }
                if (curr.right != null) {
                    q.Enqueue(curr.right);
                }
            }
            ret.Add(acc / (double) x);
        }
        return ret;
    }
}
// @lc code=end

