import java.util.PriorityQueue;
import java.util.Collections;

class MedianFinder {
    private PriorityQueue<Integer> low, high;
    
    /** initialize your data structure here. */
    public MedianFinder() {
        low = new PriorityQueue<Integer>(Collections.reverseOrder());
        high = new PriorityQueue<Integer>();
    }
    
    public void addNum(int num) {
        if (low.isEmpty() || num <= low.peek()) {
            low.offer(num);
            
            if (low.size() > high.size() + 1)
                high.offer(low.poll());
        } else {
            high.offer(num);
            
            if (high.size() > low.size() + 1)
                low.offer(high.poll());
        }
    }
    
    public double findMedian() {
        int ls = low.size(), hs = high.size();
        assert(Math.abs(ls - hs) <= 1);
        
        if (ls == hs)
            return ((double)(low.peek() + high.peek()) / 2);
        else if (ls > hs)
            return low.peek();
        else
            return high.peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */
 