import java.util.HashMap;

public class Solution {
    
    HashMap<String, HashMap<String, Double>> divs;
    HashSet<String> isVisited;
    
    public double[] calcEquation(String[][] equations, double[] values, String[][] queries) {
        int i, count = 0;
        String a, b;
        double d;
        double[] ret = new double[queries.length];
        
        this.divs = new HashMap<String, HashMap<String, Double>>();
        this.isVisited = new HashSet<String>();
        
        for (i = 0; i < equations.length; ++i) {
            a = equations[i][0];
            b = equations[i][1];
            d = values[i];
            
            if (! this.divs.containsKey(a)) {
                this.divs.put(a, new HashMap<String, Double>());
                this.divs.get(a).put(a, 1.0);
            }
            
            if (! this.divs.containsKey(b)) {
                this.divs.put(b, new HashMap<String, Double>());
                this.divs.get(b).put(b, 1.0);
            }
            
            this.divs.get(a).put(b, d);
            if (d != 0.0)
                this.divs.get(b).put(a, 1.0 / d);
        }
        
        for (String[] q : queries) {
            ret[count++] = dfs(q[0], q[1]);
            this.isVisited.clear();
        }
        
        return ret;
    }
    
    private double dfs(String a, String b) {
        double ret = -1.0, temp;
        HashMap<String, Double> hm;

        this.isVisited.add(a);
        if (! this.divs.containsKey(a)) {
            this.isVisited.remove(a);
            return ret;
        }
        hm = this.divs.get(a);
        
        for (String key : hm.keySet()) {
            if (b.equals(key)) {
                ret = hm.get(b);
                break;
            } else if (! this.isVisited.contains(key)) {
                if ((temp = dfs(key, b)) != -1.0) {
                    ret = hm.get(key) * temp;
                    break;
                }
            }
        }
            
        this.isVisited.remove(a);
        return ret;
    }
}
