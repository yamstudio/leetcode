/*
 * @lc app=leetcode id=108 lang=csharp
 *
 * [108] Convert Sorted Array to Binary Search Tree
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
public class Solution {

    private TreeNode SortedArrayToBSTRecursive(int[] nums, int start, int end) {
        if (end < start) {
            return null;
        }
        int mid = (start + end) / 2;
        var root = new TreeNode(nums[mid]);
        root.left = SortedArrayToBSTRecursive(nums, start, mid - 1);
        root.right = SortedArrayToBSTRecursive(nums, mid + 1, end);
        return root;
    }

    public TreeNode SortedArrayToBST(int[] nums) {
        return SortedArrayToBSTRecursive(nums, 0, nums.Length - 1);
    }
}

