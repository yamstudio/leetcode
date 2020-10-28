/*
 * @lc app=leetcode id=1379 lang=csharp
 *
 * [1379] Find a Corresponding Node of a Binary Tree in a Clone of That Tree
 */

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

    private static bool GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target, ref TreeNode ret) {
        if (original == null) {
            return false;
        }
        if (target == original) {
            ret = cloned;
            return true;
        }
        return GetTargetCopy(original.left, cloned.left, target, ref ret) || GetTargetCopy(original.right, cloned.right, target, ref ret);
    }

    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        TreeNode ret = null;
        GetTargetCopy(original, cloned, target, ref ret);
        return ret;
    }
}
// @lc code=end

