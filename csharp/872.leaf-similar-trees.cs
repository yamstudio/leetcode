/*
 * @lc app=leetcode id=872 lang=csharp
 *
 * [872] Leaf-Similar Trees
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
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {

    private static IEnumerable<int> GetLeafSequence(TreeNode root) {
        if (root == null) {
            return Enumerable.Empty<int>();
        }
        return GetLeafSequence(root.left)
            .Concat(GetLeafSequence(root.right))
            .DefaultIfEmpty(root.val);
    }

    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        return GetLeafSequence(root1).SequenceEqual(GetLeafSequence(root2));
    }
}
// @lc code=end

