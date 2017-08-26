import java.util.HashMap;

class Solution {
    public int leastBricks(List<List<Integer>> wall) {
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        int m = 0, pos, i;
        
        for (List<Integer> l : wall) {
            pos = 0;
            
            for (i = 0; i < l.size() - 1; ++i) {
                pos += l.get(i);
                if (hm.containsKey(pos))
                    hm.replace(pos, hm.get(pos) + 1);
                else
                    hm.put(pos, 1);
                
                m = Math.max(m, hm.get(pos));
            }
        }
        
        return wall.size() - m;
    }
}
