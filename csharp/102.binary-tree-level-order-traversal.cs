/*
 * @lc app=leetcode id=102 lang=csharp
 *
 * [102] Binary Tree Level Order Traversal
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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var ret = new List<IList<int>>();
        var list = new List<TreeNode>();
        if (root == null) {
            return ret;
        }
        list.Add(root);
        while (list.Count > 0) {
            int count = list.Count;
            var add = new List<int>();
            while (count-- > 0) {
                TreeNode node = list[0];
                list.RemoveAt(0);
                if (node.left != null) {
                    list.Add(node.left);
                }
                if (node.right != null) {
                    list.Add(node.right);
                }
                add.Add(node.val);
            }
            ret.Add(add);
        }
        return ret;
    }
}

