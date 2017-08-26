import java.util.HashMap;

class Solution {
    public int subarraySum(int[] nums, int k) {
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        int sum = 0, ret = 0;
        
        hm.put(0, 1);
        for (int num : nums) {
            sum += num;
            
            if (hm.containsKey(sum - k))
                ret += hm.get(sum - k);
            
            if (hm.containsKey(sum))
                hm.replace(sum, hm.get(sum) + 1);
            else
                hm.put(sum, 1);
        }
        
        return ret;
    }
}
