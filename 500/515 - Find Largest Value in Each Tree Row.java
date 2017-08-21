import java.util.ArrayList;
import java.util.Queue;
import java.util.LinkedList;

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
    public List<Integer> largestValues(TreeNode root) {
        List<Integer> ret = new ArrayList<Integer>();
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        TreeNode curr;
        int len, val;
        
        if (root == null)
            return ret;
        
        queue.add(root);
        while (! queue.isEmpty()) {
            len = queue.size();
            val = Integer.MIN_VALUE;
            
            while (len-- > 0) {
                curr = queue.poll();
                if (curr.left != null)
                    queue.add(curr.left);
                if (curr.right != null)
                    queue.add(curr.right);
                
                val = Math.max(val, curr.val);
            }
            
            ret.add(val);
        }
        
        return ret;
    }
}
