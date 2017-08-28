import java.util.HashMap;

class Solution {
    public int findLHS(int[] nums) {
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        int ret = 0;
        
        for (int num : nums) {
            if (hm.containsKey(num))
                hm.replace(num, hm.get(num) + 1);
            else
                hm.put(num, 1);
        }
        
        for (HashMap.Entry<Integer, Integer> e : hm.entrySet()) {
            if (hm.containsKey(e.getKey() + 1))
                ret = Math.max(ret, e.getValue() + hm.get(e.getKey() + 1));
        }
        
        return ret;
    }
}
