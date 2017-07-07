import java.util.ArrayList;
import java.util.Arrays;

public class Solution {
    public List<List<Integer>> subsetsWithDup(int[] nums) {
        ArrayList<List<Integer>> ret = new ArrayList<List<Integer>>();
        int len = nums.length;
        
        Arrays.sort(nums);
        
        helper(0, len, nums, new ArrayList<Integer>(), ret);
        
        return ret;
    }
    
    private void helper(int from, int len, int[] nums, List<Integer> prefix, List<List<Integer>> ret) {
        int i, prev, curr;

        ret.add(new ArrayList<Integer>(prefix));
        
        if (from == len)
            return;
        else
            prev = nums[from] - 1;
        
        for (i = from; i < len; ++i) {
            while (i < len && nums[i] == prev)
                ++i;
            try {
                curr = nums[i];
                prefix.add(curr);
                helper(i + 1, len, nums, prefix, ret);
                prefix.remove(prefix.size() - 1);
                prev = curr;
            } catch (ArrayIndexOutOfBoundsException e) {
                break;
            }
        }
    }
}
