import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.Comparator;

public class Solution {
    public String frequencySort(String s) {
        HashMap<Character, Integer> hm = new HashMap<Character, Integer>();
        PriorityQueue<HashMap.Entry> queue = new PriorityQueue<HashMap.Entry>(new Comparator<HashMap.Entry>() {
            @Override
            public int compare(HashMap.Entry p1, HashMap.Entry p2) {
                return (int)p2.getValue() - (int)p1.getValue();
            }
        });
        HashMap.Entry p;
        int t;
        char i;
        StringBuilder sb = new StringBuilder();
        
        for (char c : s.toCharArray()) {
            if (hm.containsKey(c))
                hm.replace(c, hm.get(c) + 1);
            else
                hm.put(c, 1);
        }
        
        for (HashMap.Entry entry : hm.entrySet())
            queue.add(entry);
        
        while (! queue.isEmpty()) {
            p = queue.poll();
            i = (char)p.getKey();
            t = (int)p.getValue();
            
            while (t-- > 0)
                sb.append(i);
        }
        
        return sb.toString();
    }
}
