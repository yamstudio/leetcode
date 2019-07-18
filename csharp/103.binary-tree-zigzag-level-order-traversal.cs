/*
 * @lc app=leetcode id=103 lang=csharp
 *
 * [103] Binary Tree Zigzag Level Order Traversal
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

using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var ret = new List<IList<int>>();
        var list = new List<TreeNode>();
        var next = new List<TreeNode>();
        bool left = false;
        list.Add(root);
        while (list.Count > 0) {
            var add = new List<int>();
            left = !left;
            foreach (TreeNode node in list) {
                if (node == null) {
                    continue;
                }
                if (left) {
                    add.Add(node.val);
                } else {
                    add.Insert(0, node.val);
                }
                next.Add(node.left);
                next.Add(node.right);
            }
            if (add.Count > 0) {
                ret.Add(add);
            }
            list.Clear();
            var tmp = list;
            list = next;
            next = tmp;
        }
        return ret;
    }
}

