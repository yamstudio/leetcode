/*
 * @lc app=leetcode id=987 lang=csharp
 *
 * [987] Vertical Order Traversal of a Binary Tree
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
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private static void VerticalTraversalRecurse(TreeNode root, int x, int y, IDictionary<(int X, int Y), IList<int>> map) {
        if (root == null) {
            return;
        }
        var key = (X: x, Y: y);
        if (!map.TryGetValue(key, out var list)) {
            list = new List<int>();
            map[key] = list;
        }
        list.Add(root.val);
        VerticalTraversalRecurse(root.left, x - 1, y - 1, map);
        VerticalTraversalRecurse(root.right, x + 1, y - 1, map);
    }

    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var map = new Dictionary<(int X, int Y), IList<int>>();
        VerticalTraversalRecurse(root, 0, 0, map);
        return map
            .GroupBy(t => t.Key.X, (int k, IEnumerable<KeyValuePair<(int X, int Y), IList<int>>> gts) => (Key: k, Value: gts
                .OrderByDescending(gt => gt.Key.Y)
                .SelectMany(gt => gt.Value.OrderBy(v => v))
                .ToList()))
            .OrderBy(t => t.Key)
            .Select<(int Key, List<int> Value), IList<int>>(t => t.Value)
            .ToList();
    }
}
// @lc code=end

