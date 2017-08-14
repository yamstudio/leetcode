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
    
    public int pathSum(TreeNode root, int sum) {
        return helper(root, sum, 0, new ArrayList<Integer>());
    }
    
    private int helper(TreeNode root, int sum, int curr, List<Integer> list) {
        int ret = 0, i, temp;
        
        if (root == null)
            return 0;   
        list.add(root.val);
        
        curr += root.val;
        if (curr == sum)
            ++ret;
        
        temp = curr;
        for (i = 0; i < list.size() - 1; ++i) {
            temp -= list.get(i);
            if (temp == sum)
                ++ret;
        }
        
        ret += helper(root.left, sum, curr, list) + helper(root.right, sum, curr, list);
        list.remove(list.size() - 1);
        
        return ret;
    }
}
