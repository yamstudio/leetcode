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
    public List<List<String>> printTree(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        List<List<String>> ret = new ArrayList<List<String>>();
        List<String> empty, list, temp;
        boolean flag;
        int len, i, j, spaces;
        TreeNode curr;
        
        if (root == null)
            return ret;
        
        queue.offer(root);
        flag = true;
        while (flag) {
            len = queue.size();
            empty = new ArrayList<String>();
            flag = false;
            
            while (len-- > 0) {
                curr = queue.poll();
                
                if (curr == null) {
                    empty.add("");
                    queue.offer(null);
                    queue.offer(null);
                } else {
                    empty.add(Integer.toString(curr.val));
                    queue.offer(curr.left);
                    queue.offer(curr.right);
                    
                    if ((! flag) && (curr.left != null || curr.right != null))
                        flag = true;
                }
            }
            
            ret.add(empty);
        }
        
        empty = new ArrayList<String>();
        spaces = 0;
        for (i = ret.size() - 1; i >= 0; --i) {
            empty.clear();
            list = ret.get(i);
            
            for (j = 0; j < list.size(); ++j) {
                if (j == 0)
                    padSpaces(empty, spaces);
                else
                    padSpaces(empty, spaces + 1);
                empty.add(list.get(j));
                padSpaces(empty, spaces);
            }
            
            temp = list;
            ret.set(i, empty);
            empty = temp;
            
            spaces = 2 * spaces + 1;
        }
        
        return ret;
    }
    
    private static void padSpaces(List<String> list, int count) {
        while (count-- > 0)
            list.add("");
    }
}
