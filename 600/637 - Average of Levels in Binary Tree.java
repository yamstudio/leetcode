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
    public List<Double> averageOfLevels(TreeNode root) {
        int len, i;
        double sum;
        TreeNode curr;
        List<Double> ret = new ArrayList<Double>();
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        
        if (root == null)
            return ret;
        queue.offer(root);
        
        while (! queue.isEmpty()) {
            sum = 0.0;
            len = queue.size();
            
            for (i = 0; i < len; ++i) {
                curr = queue.poll();
                if (curr.left != null)
                    queue.offer(curr.left);
                if (curr.right != null)
                    queue.offer(curr.right);
                
                sum += curr.val;
            }
            
            ret.add(sum / (1.0 * len));
        }
        
        return ret;
    }
}
