/*
 * @lc app=leetcode id=257 lang=csharp
 *
 * [257] Binary Tree Paths
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
    public IList<string> BinaryTreePaths(TreeNode root) {
        if (root == null) {
            return Array.Empty<string>();
        }
        var ret = new List<string>();
        foreach (string s in BinaryTreePaths(root.left)) {
            ret.Add($"{root.val}->{s}");
        }
        foreach (string s in BinaryTreePaths(root.right)) {
            ret.Add($"{root.val}->{s}");
        }
        if (ret.Count == 0) {
            ret.Add($"{root.val}");
        }
        return ret;
    }
}

