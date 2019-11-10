/*
 * @lc app=leetcode id=652 lang=csharp
 *
 * [652] Find Duplicate Subtrees
 */

using System.Collections.Generic;

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

    private static string FindDuplicateSubtreesRecurse(TreeNode root, IList<TreeNode> ret, IDictionary<string, int> map) {
        if (root == null) {
            return "-";
        }
        string s = $"{root.val},{FindDuplicateSubtreesRecurse(root.left, ret, map)},{FindDuplicateSubtreesRecurse(root.right, ret, map)}";
        int val = 0;
        map.TryGetValue(s, out val);
        if (val == 1) {
            ret.Add(root);
        }
        map[s] = val + 1;
        return s;
    }

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        IList<TreeNode> ret = new List<TreeNode>();
        FindDuplicateSubtreesRecurse(root, ret, new Dictionary<string, int>());
        return ret;
    }
}
// @lc code=end

