import java.util.HashMap;

public class Solution {
    public int lengthLongestPath(String input) {
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        int ret = 0, level, len;
        
        hm.put(0, 0);
        
        for (String name : input.split("\n")) {
            level = name.lastIndexOf("\t") + 1;
            len = name.length() - level;
            
            if (name.contains("."))
                ret = Math.max(ret, hm.get(level) + len);
            else
                hm.put(level + 1, hm.get(level) + len + 1);
        }
        
        return ret;
    }
}
