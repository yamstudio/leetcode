import java.util.HashMap;

class Solution {
    public int findMaxLength(int[] nums) {
        int ret = 0, i, count = 0;
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        
        hm.put(0, -1);
        for (i = 0; i < nums.length; ++i) {
            if (nums[i] == 1)
                ++count;
            else
                --count;
            
            if (hm.containsKey(count))
                ret = Math.max(ret, i - hm.get(count));
            else
                hm.put(count, i);
        }
        
        return ret;
    }
}
