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
    public TreeNode convertBST(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        int sum = 0;
        TreeNode curr = root;
        
        while (curr != null || ! stack.isEmpty()) {
            while (curr != null) {
                stack.push(curr);
                curr = curr.right;
            }
            
            curr = stack.pop();
            curr.val += sum;
            sum = curr.val;
            curr = curr.left;
        }
        
        return root;
    }
}
