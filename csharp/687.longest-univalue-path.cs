/*
 * @lc app=leetcode id=687 lang=csharp
 *
 * [687] Longest Univalue Path
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

    private static (int, int) LongestUnivaluePathRecurse(TreeNode root) {
        TreeNode left = root.left, right = root.right;
        int val = root.val, ret = 0, len = 0;
        if (left != null) {
            var pair = LongestUnivaluePathRecurse(left);
            ret = pair.Item1;
            if (val == left.val) {
                len = 1 + pair.Item2;
                ret = Math.Max(len, ret);
            }
        }
        if (right != null) {
            var pair = LongestUnivaluePathRecurse(right);
            ret = Math.Max(ret, pair.Item1);
            if (val == right.val) {
                ret = Math.Max(len + 1 + pair.Item2, ret);
                len = Math.Max(len, 1 + pair.Item2);
            }
        }
        return (ret, len);
    }

    public int LongestUnivaluePath(TreeNode root) {
        if (root == null) {
            return 0;
        }
        return LongestUnivaluePathRecurse(root).Item1;
    }
}
// @lc code=end

