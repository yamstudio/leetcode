import java.util.ArrayList;
import java.util.HashSet;

class Solution {
    public List<List<Integer>> findSubsequences(int[] nums) {
        HashSet<List<Integer>> set = new HashSet<List<Integer>>();
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        
        helper(nums, 0, new ArrayList<Integer>(), set);
        
        ret.addAll(set);
        return ret;
    }
    
    private void helper(int[] nums, int from, List<Integer> prefix, HashSet<List<Integer>> set) {
        int i;

        if (prefix.size() >= 2)
            set.add(new ArrayList<Integer>(prefix));
        
        for (i = from; i < nums.length; ++i) {
            if ((! prefix.isEmpty()) && prefix.get(prefix.size() - 1) > nums[i])
                continue;
            prefix.add(nums[i]);
            if (! set.contains(prefix))
                helper(nums, i + 1, prefix, set);
            prefix.remove(prefix.size() - 1);
        }
    }
}
