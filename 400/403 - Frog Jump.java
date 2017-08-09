import java.util.HashMap;

public class Solution {
    public boolean canCross(int[] stones) {
        HashMap<Integer, Boolean> hm = new HashMap<Integer, Boolean>();
        return helper(stones, 0, 0, hm);
    }
    
    private boolean helper(int[] stones, int index, int jump, HashMap<Integer, Boolean> hm) {
        int k = index | (jump << 11), i, d;
        
        if (index >= stones.length - 1)
            return true;
        
        if (hm.containsKey(k))
            return hm.get(k);
        
        for (i = index + 1; i < stones.length; ++i) {
            d = stones[i] - stones[index];
            
            if (d < jump - 1)
                continue;
            
            if (d > jump + 1)
                break;
            
            if (helper(stones, i, d, hm)) {
                hm.put(k, true);
                return true;
            }
        }
        
        hm.put(k, false);
        return false;
    }
}
