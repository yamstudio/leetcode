/*
 * @lc app=leetcode id=655 lang=csharp
 *
 * [655] Print Binary Tree
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

    private static int GetHeight(TreeNode root) {
        if (root == null) {
            return 0;
        }
        return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
    }

    private static void GetMap(TreeNode root, IDictionary<(int, int), int> map, int height, int level, int start, int end) {
        if (root == null) {
            return;
        }
        int mid = (start + end) / 2;
        map[(level, mid)] = root.val;
        GetMap(root.left, map, height, level + 1, start, mid - 1);
        GetMap(root.right, map, height, level + 1, mid + 1, end);
    }

    public IList<IList<string>> PrintTree(TreeNode root) {
        int height = GetHeight(root), width = (1 << height) - 1;
        var map = new Dictionary<(int, int), int>();
        GetMap(root, map, height, 0, 0, width - 1);
        return Enumerable.Range(0, height).Select<int, IList<string>>(r => Enumerable.Range(0, width).Select(c => {
            int val;
            if (map.TryGetValue((r, c), out val)) {
                return val.ToString();
            }
            return "";
        }).ToList()).ToList();
    }
}
// @lc code=end

