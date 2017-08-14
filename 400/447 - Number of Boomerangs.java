import java.util.HashMap;

public class Solution {
    public int numberOfBoomerangs(int[][] points) {
        int i, j, ret = 0, t;
        long x1, y1, dx, dy, val;
        HashMap<Long, Integer> hm = new HashMap<Long, Integer>();
        
        for (i = 0; i < points.length; ++i) {
            x1 = points[i][0];
            y1 = points[i][1];
            hm.clear();
            
            for (j = 0; j < points.length; ++j) {
                dx = points[j][0] - x1;
                dy = points[j][1] - y1;
                val = dx * dx + dy * dy;
                
                if (hm.containsKey(val))
                    hm.replace(val, hm.get(val) + 1);
                else
                    hm.put(val, 1);
            }
            
            for (HashMap.Entry<Long, Integer> p : hm.entrySet()) {
                t = p.getValue();
                ret += t * (t - 1);
            }
        }
        
        return ret;
    }
}
