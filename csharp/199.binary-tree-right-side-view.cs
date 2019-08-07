/*
 * @lc app=leetcode id=199 lang=csharp
 *
 * [199] Binary Tree Right Side View
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        var ret = new List<int>();
        var queue = new Queue<TreeNode>();
        if (root != null) {
            queue.Enqueue(root);
        }
        int count;
        while ((count = queue.Count) > 0) {
            TreeNode curr = null;
            while (count-- > 0) {
                curr = queue.Dequeue();
                if (curr.left != null) {
                    queue.Enqueue(curr.left);
                }
                if (curr.right != null) {
                    queue.Enqueue(curr.right);
                }
            }
            ret.Add(curr.val);
        }
        return ret;
    }
}

