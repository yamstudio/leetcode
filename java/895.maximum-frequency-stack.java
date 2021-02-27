/*
 * @lc app=leetcode id=895 lang=java
 *
 * [895] Maximum Frequency Stack
 */

// @lc code=start
class FreqStack {

    private Map<Integer, Integer> freqs;
    private Map<Integer, Stack<Integer>> elements;
    private int max;

    public FreqStack() {
        freqs = new HashMap<Integer, Integer>();
        elements = new HashMap<Integer, Stack<Integer>>();
        max = 0;
    }
    
    public void push(int x) {
        int freq = freqs.getOrDefault(x, 0) + 1;
        freqs.put(x, freq);
        if (!elements.containsKey(freq)) {
            elements.put(freq, new Stack<Integer>());
        }
        elements.get(freq).push(x);
        max = Math.max(freq, max);
    }
    
    public int pop() {
        Stack<Integer> curr = elements.get(max);
        int ret = curr.pop();
        freqs.put(ret, max - 1);
        if (curr.size() == 0) {
            --max;
        }
        return ret;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.push(x);
 * int param_2 = obj.pop();
 */
// @lc code=end

