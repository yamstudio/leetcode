/*
 * @lc app=leetcode id=501 lang=csharp
 *
 * [501] Find Mode in Binary Search Tree
 */

using System.Collections.Generic;
using System.Linq;

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
    public int[] FindMode(TreeNode root) {
        var stack = new List<TreeNode>();
        var ret = new List<TreeNode>();
        TreeNode curr = root, prev = null;
        int count = 0, max = 0;
        while (curr != null || stack.Count > 0) {
            while (curr != null) {
                stack.Add(curr);
                curr = curr.left;
            }
            curr = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            if (prev == null || prev.val != curr.val) {
                count = 1;
            } else {
                count++;
            }
            if (count >= max) {
                if (count > max) {
                    ret.Clear();
                    max = count;
                }
                ret.Add(curr);
            }
            prev = curr;
            curr = curr.right;
        }
        return ret.Select(node => node.val).ToArray();
    }
}
// @lc code=end

