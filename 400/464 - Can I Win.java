import java.util.HashMap;

public class Solution {
    public boolean canIWin(int maxChoosableInteger, int desiredTotal) {
        if (maxChoosableInteger >= desiredTotal)
            return true;
        
        if (maxChoosableInteger * (maxChoosableInteger + 1) / 2 < desiredTotal)
            return false;
        
        return helper(maxChoosableInteger, desiredTotal, 0, new HashMap<Integer, Boolean>());
    }
    
    private boolean helper(int len, int total, int used, HashMap<Integer, Boolean> hm) {
        int i, mask;
        
        if (hm.containsKey(used))
            return hm.get(used);
        
        for (i = 0; i < len; ++i) {
            mask = 1 << i;
            
            if ((mask & used) == 0) {
                if (total <= i + 1 || ! helper(len, total - i - 1, used | mask, hm)) {
                    hm.put(used, true);
                    return true;
                }
            }
        }
        
        hm.put(used, false);
        return false;
    }
}
