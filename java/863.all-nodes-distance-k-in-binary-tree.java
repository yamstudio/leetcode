/*
 * @lc app=leetcode id=863 lang=java
 *
 * [863] All Nodes Distance K in Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    public List<Integer> distanceK(TreeNode root, TreeNode target, int K) {
        Map<TreeNode, TreeNode> map = new HashMap<TreeNode, TreeNode>();
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        Set<TreeNode> visited = new HashSet<TreeNode>();
        queue.offer(root);
        while (queue.size() > 0) {
            TreeNode curr = queue.poll();
            if (curr.left != null) {
                map.put(curr.left, curr);
                queue.offer(curr.left);
            }
            if (curr.right != null) {
                map.put(curr.right, curr);
                queue.offer(curr.right);
            }
        }
        visited.add(target);
        queue.offer(target);
        while (K-- > 0) {
            for (int i = queue.size(); i > 0; --i) {
                TreeNode curr = queue.poll();
                if (curr.left != null && visited.add(curr.left)) {
                    queue.offer(curr.left);
                }
                if (curr.right != null && visited.add(curr.right)) {
                    queue.offer(curr.right);
                }
                if (map.containsKey(curr)) {
                    TreeNode parent = map.get(curr);
                    if (visited.add(parent)) {
                        queue.offer(parent);
                    }
                }
            }
        }
        return queue.stream().map(t -> t.val).collect(Collectors.toList());
    }
}
// @lc code=end

