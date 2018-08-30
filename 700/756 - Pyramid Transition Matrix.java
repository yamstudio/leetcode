import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

class Solution {
    private boolean build(String curr, String base, Map<String, Set<String>> map) {
        int currLen = curr.length(), baseLen = base.length();
        
        if (currLen == baseLen - 1) {
            return currLen == 1 || build("", curr, map);
        }
        
        String key = base.substring(currLen, currLen + 2);
        Set<String> set = map.get(key);
        
        if (set != null) {
            for (String c : set) {
                if (build(curr + c, base, map)) {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    public boolean pyramidTransition(String bottom, List<String> allowed) {
        HashMap<String, Set<String>> map = new HashMap<>();
        for (String s : allowed) {
            String key = s.substring(0, 2);
            String val = s.substring(2);
            Set<String> vals = map.get(key);
            
            if (vals == null) {
                vals = new HashSet<>();
                map.put(key, vals);
            }
            vals.add(val);
        }
        
        return build("", bottom, map);
    }
}