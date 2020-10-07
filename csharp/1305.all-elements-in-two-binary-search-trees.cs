/*
 * @lc app=leetcode id=1305 lang=csharp
 *
 * [1305] All Elements in Two Binary Search Trees
 */

using System.Collections.Generic;
using System.Linq;

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

    private static IEnumerable<int> Traverse(TreeNode root) {
        if (root == null) {
            return Enumerable.Empty<int>();
        }
        return Traverse(root.left).Append(root.val).Concat(Traverse(root.right));
    }

    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
        int[] v1 = Traverse(root1).ToArray(), v2 = Traverse(root2).ToArray();
        int l1 = v1.Length, l2 = v2.Length, i = 0, j = 0;
        var ret = new List<int>(l1 + l2);
        while (i < l1 && j < l2) {
            if (v1[i] < v2[j]) {
                ret.Add(v1[i++]);
            } else {
                ret.Add(v2[j++]);
            }
        }
        for (; i < l1; ++i) {
            ret.Add(v1[i]);
        }
        for (; j < l2; ++j) {
            ret.Add(v2[j]);
        }
        return ret;
    }
}
// @lc code=end

