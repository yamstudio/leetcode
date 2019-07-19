/*
 * @lc app=leetcode id=107 lang=csharp
 *
 * [107] Binary Tree Level Order Traversal II
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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        var ret = new List<IList<int>>();
        var queue = new List<TreeNode>();
        int count;
        queue.Add(root);
        while ((count = queue.Count) != 0) {
            var add = new List<int>();
            while (count-- > 0) {
                var node = queue[0];
                queue.RemoveAt(0);
                if (node == null) {
                    continue;
                }
                queue.Add(node.left);
                queue.Add(node.right);
                add.Add(node.val);
            }
            if (add.Count > 0) {
                ret.Add(add);
            }
        }
        ret.Reverse();
        return ret;
    }
}

