/*
 * @lc app=leetcode id=987 lang=java
 *
 * [987] Vertical Order Traversal of a Binary Tree
 */

import java.util.ArrayList;
import java.util.List;
import java.util.TreeMap;

// @lc code=start
import java.util.SortedMap;

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
    public List<List<Integer>> verticalTraversal(TreeNode root) {
        SortedMap<Integer, SortedMap<Integer, List<Integer>>> xToYToVals = new TreeMap<>();
        helper(root, 0, 0, xToYToVals);
        List<List<Integer>> ret = new ArrayList<>(xToYToVals.size());
        for (var yToVals : xToYToVals.values()) {
            var vals = new ArrayList<Integer>();
            for (var yVals: yToVals.values()) {
                yVals.stream().sorted().forEach(vals::add);
            }
            ret.add(vals);
        }
        return ret;
    }

    private static void helper(TreeNode curr, int x, int y, SortedMap<Integer, SortedMap<Integer, List<Integer>>> xToYToVals) {
        if (curr == null) {
            return;
        }
        xToYToVals.computeIfAbsent(x, ignored -> new TreeMap<>())
            .computeIfAbsent(-y, ignored -> new ArrayList<>())
            .add(curr.val);
        helper(curr.left, x - 1, y - 1, xToYToVals);
        helper(curr.right, x + 1, y - 1, xToYToVals);
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
