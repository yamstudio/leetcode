import java.util.HashMap;
import java.util.PriorityQueue;

class Solution {
    public boolean isPossible(int[] nums) {
        HashMap<Integer, PriorityQueue<Integer>> hm = new HashMap<Integer, PriorityQueue<Integer>>();
        PriorityQueue<Integer> qPrev, qCurr;
        int val;
        
        for (int num : nums) {
            qPrev = getQueue(hm, num - 1);
            qCurr = getQueue(hm, num);
            val = qPrev.isEmpty() ? 0 : qPrev.poll();
            qCurr.offer(val + 1);
        }
        
        for (int d : hm.keySet()) {
            for (int l : hm.get(d)) {
                if (l < 3)
                    return false;
            }
        }
        
        return true;
    }
    
    private PriorityQueue<Integer> getQueue(HashMap<Integer, PriorityQueue<Integer>> hm, int num) {
        PriorityQueue<Integer> queue = hm.get(num);
        
        if (queue == null) {
            queue = new PriorityQueue<Integer>();
            hm.put(num, queue);
        }
        
        return queue;
    }
}
