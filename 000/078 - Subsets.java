import java.util.ArrayList;
import java.util.Arrays;

public class Solution {
    public List<List<Integer>> subsets(int[] nums) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        List<Integer> avail = new ArrayList<Integer>();
        int i;
        
        for (i = 0; i < nums.length; ++i)
            avail.add(nums[i]);
        
        helper(avail, new ArrayList<Integer>(), ret);
        
        return ret;
    }
    
    private void helper(List<Integer> avail, List<Integer> prefix, List<List<Integer>> ret) {
        int i, c;
        
        ret.add(new ArrayList<Integer>(prefix));
        for (i = 0; i < avail.size(); ++i) {
            c = avail.get(i);
            prefix.add(c);
            try {
                helper(avail.subList(i + 1, avail.size()), prefix, ret);
            } catch (IndexOutOfBoundsException e) {
                ret.add(new ArrayList<Integer>(prefix));
            }
            prefix.remove(prefix.size() - 1);
        }
    }
}
