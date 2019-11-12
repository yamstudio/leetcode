/*
 * @lc app=leetcode id=653 lang=csharp
 *
 * [653] Two Sum IV - Input is a BST
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

    private static bool FindTargetRecurse(TreeNode root, ISet<int> set, int k) {
        if (root == null) {
            return false;
        }
        if (set.Contains(k - root.val)) {
            return true;
        }
        set.Add(root.val);
        return FindTargetRecurse(root.left, set, k) || FindTargetRecurse(root.right, set, k);
    }

    public bool FindTarget(TreeNode root, int k) {
        return FindTargetRecurse(root, new HashSet<int>(), k);
    }
}
// @lc code=end

