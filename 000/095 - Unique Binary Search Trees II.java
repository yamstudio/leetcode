import java.util.ArrayList;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public List<TreeNode> generateTrees(int n) {
        if (n > 0)
            return helper(1, n);
        else
            return new ArrayList<TreeNode>();
    }
    
    private List<TreeNode> helper(int from, int to) {
        List<TreeNode> ret = new ArrayList<TreeNode>(), left, right;
        int i, j, k;
        TreeNode temp;
        
        if (from > to) {
            ret.add(null);
            return ret;
        }
        
        for (i = from; i <= to; ++i) {
            left = helper(from, i - 1);
            right = helper(i + 1, to);
            for (j = 0; j < left.size(); ++j) {
                for (k = 0; k < right.size(); ++k) {
                    temp = new TreeNode(i);
                    temp.left = left.get(j);
                    temp.right = right.get(k);
                    ret.add(temp);
                }
            }
        }
        
        return ret;
    }
}
