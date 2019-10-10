/*
 * @lc app=leetcode id=508 lang=csharp
 *
 * [508] Most Frequent Subtree Sum
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

using System.Collections.Generic;
using System.Linq;

public class Solution {

    private static int FindFrequentTreeSumRecurse(TreeNode root, IDictionary<int, int> count) {
        if (root == null) {
            return 0;
        }
        int val = FindFrequentTreeSumRecurse(root.left, count) + FindFrequentTreeSumRecurse(root.right, count) + root.val;
        if (!count.ContainsKey(val)) {
            count[val] = 1;
        } else {
            count[val]++;
        }
        return val;
    }

    public int[] FindFrequentTreeSum(TreeNode root) {
        if (root == null) {
            return new int[0];
        }
        IDictionary<int, int> count = new Dictionary<int, int>();
        FindFrequentTreeSumRecurse(root, count);
        int max = count.Values.Max();
        return count.Keys.Where(key => count[key] == max).ToArray();
    }
}
// @lc code=end

