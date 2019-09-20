/*
 * @lc app=leetcode id=437 lang=csharp
 *
 * [437] Path Sum III
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

using System.Collections.Generic;

public class Solution {

    private static int PathSumRecurse(TreeNode curr, IDictionary<int, int> count, int target, int sum) {
        if (curr == null) {
            return 0;
        }
        sum += curr.val;
        int ret = count.ContainsKey(sum - target) ? count[sum - target] : 0;
        count[sum] = (count.ContainsKey(sum) ? count[sum] : 0) + 1;
        ret += PathSumRecurse(curr.left, count, target, sum) + PathSumRecurse(curr.right, count, target, sum);
        --count[sum];
        return ret;
    }

    public int PathSum(TreeNode root, int sum) {
        var count = new Dictionary<int, int>();
        count[0] = 1;
        return PathSumRecurse(root, count, sum, 0);
    }
}

