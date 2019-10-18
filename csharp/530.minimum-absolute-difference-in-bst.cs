/*
 * @lc app=leetcode id=530 lang=csharp
 *
 * [530] Minimum Absolute Difference in BST
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

    private static (int, int, int) GetMinimumDifferenceRecurse(TreeNode root) {
        int val = root.val, min = val, max = val, diff = int.MaxValue;
        var left = root.left;
        var right = root.right;
        if (left != null) {
            var pair = GetMinimumDifferenceRecurse(left);
            min = pair.Item1;
            diff = Math.Min(Math.Min(diff, pair.Item3), val - pair.Item2);
        }
        if (right != null) {
            var pair = GetMinimumDifferenceRecurse(right);
            max = pair.Item2;
            diff = Math.Min(Math.Min(diff, pair.Item3), pair.Item1 - val);
        }
        return (min, max, diff);
    }

    public int GetMinimumDifference(TreeNode root) {
        return GetMinimumDifferenceRecurse(root).Item3;
    }
}
// @lc code=end

