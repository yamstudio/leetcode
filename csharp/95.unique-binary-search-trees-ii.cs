/*
 * @lc app=leetcode id=95 lang=csharp
 *
 * [95] Unique Binary Search Trees II
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
    public IList<TreeNode> GenerateTrees(int n) {
        IDictionary<(int, int), IList<TreeNode>> map = new Dictionary<(int, int), IList<TreeNode>>();
        IList<TreeNode> empty = new List<TreeNode>(1);
        empty.Add(null);
        if (n == 0) {
            return Array.Empty<TreeNode>();
        }
        for (int i = 1; i <= n; ++i) {
            IList<TreeNode> list = new List<TreeNode>(1);
            list.Add(new TreeNode(i));
            map[(i, i)] = list;
        }
        for (int len = 2; len <= n; ++len) {
            for (int start = 1; start <= n + 1 - len; ++start) {
                int end = start + len - 1;
                IList<TreeNode> list = new List<TreeNode>();
                for (int rootVal = start; rootVal <= end; ++rootVal) {
                    (int, int) leftRange = (start, rootVal - 1), rightRange = (rootVal + 1, end);
                    IList<TreeNode> leftSubs = map.ContainsKey(leftRange) ? map[leftRange] : empty, rightSubs = map.ContainsKey(rightRange) ? map[rightRange] : empty;
                    foreach (TreeNode left in leftSubs) {
                        foreach (TreeNode right in rightSubs) {
                            TreeNode root = new TreeNode(rootVal);
                            root.left = left;
                            root.right = right;
                            list.Add(root);
                        }
                    }
                }
                map[(start, end)] = list;
            }
        }
        return map[(1, n)];
    }
}

