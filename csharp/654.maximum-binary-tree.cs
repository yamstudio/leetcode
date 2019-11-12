/*
 * @lc app=leetcode id=654 lang=csharp
 *
 * [654] Maximum Binary Tree
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
    
    private TreeNode ConstructMaximumBinaryTreeRecurse(int[] nums, int start, int end) {
        if (end < start) {
            return null;
        }
        int mi = start;
        for (int i = start + 1; i <= end; ++i) {
            if (nums[i] > nums[mi]) {
                mi = i;
            }
        }
        TreeNode ret = new TreeNode(nums[mi]);
        ret.left = ConstructMaximumBinaryTreeRecurse(nums, start, mi - 1);
        ret.right = ConstructMaximumBinaryTreeRecurse(nums, mi + 1, end);
        return ret;
    }
    
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        return ConstructMaximumBinaryTreeRecurse(nums, 0, nums.Length - 1);
    }
}
// @lc code=end

