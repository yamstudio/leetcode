import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Random;
import java.util.Set;

class Solution {

    private Map<Integer, Integer> map;
    private Random random;
    private int max;
    
    public Solution(int N, int[] blacklist) {
        random = new Random();
        map = new HashMap<>();
        max = N - blacklist.length;
        Set<Integer> set = new HashSet<>();
        int i = N - 1;
        
        for (int num : blacklist) {
            set.add(num);
        }
        
        for (Integer num : set) {
            if (num >= max) {
                continue;
            }
            
            while (set.contains(i)) {
                --i;
            }
            
            map.put(num, i--);
        }
    }
    
    public int pick() {
        int rand = random.nextInt(max);
        
        return map.containsKey(rand) ? map.get(rand) : rand;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(N, blacklist);
 * int param_1 = obj.pick();
 */