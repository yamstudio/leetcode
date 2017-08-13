import java.util.HashMap;

public class Solution {
    public int fourSumCount(int[] A, int[] B, int[] C, int[] D) {
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        int sum, ret = 0;
        
        for (int a : A) {
            for (int b : B) {
                sum = a + b;
                if (hm.containsKey(sum))
                    hm.replace(sum, hm.get(sum) + 1);
                else
                    hm.put(sum, 1);
            }
        }
        
        for (int c: C) {
            for (int d : D) {
                sum = -1 * (c + d);
                
                if (hm.containsKey(sum))
                    ret += hm.get(sum);
            }
        }
        
        return ret;
    }
}
