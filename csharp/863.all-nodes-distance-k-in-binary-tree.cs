/*
 * @lc app=leetcode id=863 lang=csharp
 *
 * [863] All Nodes Distance K in Binary Tree
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
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        var parents = new Dictionary<TreeNode, TreeNode>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var curr = queue.Dequeue();
            if (curr.left != null) {
                parents[curr.left] = curr;
                queue.Enqueue(curr.left);
            }
            if (curr.right != null) {
                parents[curr.right] = curr;
                queue.Enqueue(curr.right);
            }
        }
        var visited = new HashSet<TreeNode>();
        visited.Add(target);
        queue.Enqueue(target);
        while (K-- > 0 && queue.Count > 0) {
            for (int j = queue.Count; j > 0; --j) {
                var curr = queue.Dequeue();
                if (parents.TryGetValue(curr, out var parent) && !visited.Contains(parent)) {
                    visited.Add(parent);
                    queue.Enqueue(parent);
                }
                if (curr.left != null && !visited.Contains(curr.left)) {
                    visited.Add(curr.left);
                    queue.Enqueue(curr.left);
                }
                if (curr.right != null && !visited.Contains(curr.right)) {
                    visited.Add(curr.right);
                    queue.Enqueue(curr.right);
                }
            }
        }
        return queue.Select(node => node.val).ToList();
    }
}
// @lc code=end

