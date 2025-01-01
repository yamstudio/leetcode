/*
 * @lc app=leetcode id=1161 lang=java
 *
 * [1161] Maximum Level Sum of a Binary Tree
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    public int maxLevelSum(TreeNode root) {
        Map<Integer, Integer> sum = new HashMap<>();
        helper(root, 1, sum);
        int ret = Integer.MAX_VALUE, maxSum = Integer.MIN_VALUE;
        for (var entry : sum.entrySet()) {
            int v = entry.getValue(), k = entry.getKey();
            if (v > maxSum || (v == maxSum && k < ret)) {
                maxSum = v;
                ret = k;
            }
        }
        return ret;
    }

    private static void helper(TreeNode root, int level, Map<Integer, Integer> sum) {
        if (root == null) {
            return;
        }
        sum.put(level, sum.getOrDefault(level, 0) + root.val);
        helper(root.left, level + 1, sum);
        helper(root.right, level + 1, sum);
    }
}
// @lc code=end

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() {}
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
