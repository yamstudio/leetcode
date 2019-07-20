/*
 * @lc app=leetcode id=113 lang=csharp
 *
 * [113] Path Sum II
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

    private void PathSumPreorder(TreeNode root, int sum, IList<IList<int>> ret, IList<int> curr) {
        if (root == null) {
            return;
        }
        curr.Add(root.val);
        sum -= root.val;
        if (root.left == null && root.right == null && sum == 0) {
            ret.Add(new List<int>(curr));
        }
        if (root.left != null) {
            PathSumPreorder(root.left, sum, ret, curr);
        }
        if (root.right != null) {
            PathSumPreorder(root.right, sum, ret, curr);
        }
        curr.RemoveAt(curr.Count - 1);
    }

    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        var ret = new List<IList<int>>();
        PathSumPreorder(root, sum, ret, new List<int>());
        return ret;
    }
}

