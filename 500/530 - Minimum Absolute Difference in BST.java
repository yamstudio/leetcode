import java.util.Stack;

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
    public int getMinimumDifference(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = root, prev = null;
        int ret = Integer.MAX_VALUE;
        
        while (curr != null || ! stack.isEmpty()) {
            while (curr != null) {
                stack.push(curr);
                curr = curr.left;
            }
            
            curr = stack.pop();
            if (prev != null)
                ret = Math.min(ret, curr.val - prev.val);
            prev = curr;
            curr = curr.right;
        }
        
        return ret;
    }
}
