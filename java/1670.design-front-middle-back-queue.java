/*
 * @lc app=leetcode id=1670 lang=java
 *
 * [1670] Design Front Middle Back Queue
 */

import java.util.ArrayDeque;
import java.util.Deque;

// @lc code=start

class FrontMiddleBackQueue {

    private final Deque<Integer> l, r;

    public FrontMiddleBackQueue() {
        l = new ArrayDeque<>();
        r = new ArrayDeque<>();
    }
    
    public void pushFront(int val) {
        l.addFirst(val);
        balance();
    }
    
    public void pushMiddle(int val) {
        r.addFirst(val);
        balance();
    }
    
    public void pushBack(int val) {
        r.addLast(val);
        balance();
    }
    
    public int popFront() {
        int ret = l.isEmpty() ? (r.isEmpty() ? -1 : r.removeFirst()) : l.removeFirst();
        balance();
        return ret;
    }
    
    public int popMiddle() {
        int ret = r.isEmpty() ? -1 : l.size() == r.size() ? l.removeLast() : r.removeFirst();
        balance();
        return ret;
    }
    
    public int popBack() {
        int ret = r.isEmpty() ? -1 : r.removeLast();
        balance();
        return ret;
    }

    private void balance() {
        while (l.size() > r.size()) {
            r.addFirst(l.removeLast());
        }
        while (r.size() > l.size() + 1) {
            l.addLast(r.removeFirst());
        }
    }
}

/**
 * Your FrontMiddleBackQueue object will be instantiated and called as such:
 * FrontMiddleBackQueue obj = new FrontMiddleBackQueue();
 * obj.pushFront(val);
 * obj.pushMiddle(val);
 * obj.pushBack(val);
 * int param_4 = obj.popFront();
 * int param_5 = obj.popMiddle();
 * int param_6 = obj.popBack();
 */
// @lc code=end

