/*
 * @lc app=leetcode id=1825 lang=java
 *
 * [1825] Finding MK Average
 */

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.TreeMap;

// @lc code=start

class MKAverage {

    private final TreeMap<Integer, Integer> count;
    private final Deque<Integer> deque;
    private final int m;
    private final int k;
    private int sum;

    public MKAverage(int m, int k) {
        this.m = m;
        this.k = k;
        count = new TreeMap<>();
        deque = new ArrayDeque<>(m);
        sum = 0;
    }
    
    public void addElement(int num) {
        if (deque.size() == m) {
            int r = deque.removeFirst(), v = count.get(r);
            if (v == 1) {
                count.remove(r);
            } else {
                count.put(r, v - 1);
            }
            sum -= r;
        }
        deque.addLast(num);
        count.put(num, count.getOrDefault(num, 0) + 1);
        sum += num;
    }
    
    public int calculateMKAverage() {
        if (deque.size() != m) {
            return -1;
        }
        int acc = sum, rem = k;
        for (var entry : count.entrySet()) {
            int c = Math.min(entry.getValue(), rem);
            acc -= c * entry.getKey();
            rem -= c;
            if (rem == 0) {
                break;
            }
        }
        rem = k;
        for (var entry : count.descendingMap().entrySet()) {
            int c = Math.min(entry.getValue(), rem);
            acc -= c * entry.getKey();
            rem -= c;
            if (rem == 0) {
                break;
            }
        }
        return acc / (m - 2 * k);
    }
}

/**
 * Your MKAverage object will be instantiated and called as such:
 * MKAverage obj = new MKAverage(m, k);
 * obj.addElement(num);
 * int param_2 = obj.calculateMKAverage();
 */
// @lc code=end

