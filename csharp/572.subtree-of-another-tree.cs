/*
 * @lc app=leetcode id=572 lang=csharp
 *
 * [572] Subtree of Another Tree
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

    private static bool IsEqual(TreeNode s, TreeNode t) {
        if (s == null) {
            return t == null;
        }
        if (t == null) {
            return false;
        }
        return s.val == t.val && IsEqual(s.left, t.left) && IsEqual(s.right, t.right);
    }

    public bool IsSubtree(TreeNode s, TreeNode t) {
        if (s == null) {
            return t == null;
        }
        if (t == null) {
            return false;
        }
        return IsSubtree(s.right, t) || IsSubtree(s.left, t) || IsEqual(s, t);
    }
}
// @lc code=end

