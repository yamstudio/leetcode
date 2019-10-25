/*
 * @lc app=leetcode id=563 lang=csharp
 *
 * [563] Binary Tree Tilt
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

    private static (int, int) FindTiltRecurse(TreeNode root) {
        if (root == null) {
            return (0, 0);
        }
        var l = FindTiltRecurse(root.left);
        var r = FindTiltRecurse(root.right);
        return (l.Item1 + r.Item1 + root.val, l.Item2 + r.Item2 + Math.Abs(l.Item1 - r.Item1));
    }

    public int FindTilt(TreeNode root) {
        return FindTiltRecurse(root).Item2;
    }
}
// @lc code=end

