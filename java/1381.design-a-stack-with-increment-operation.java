/*
 * @lc app=leetcode id=1381 lang=java
 *
 * [1381] Design a Stack With Increment Operation
 */

// @lc code=start
class CustomStack {

    private final int[] stack;
    private final int[] increments;
    private int index;

    public CustomStack(int maxSize) {
        stack = new int[maxSize];
        increments = new int[maxSize];
        index = -1;
    }
    
    public void push(int x) {
        if (index == stack.length - 1) {
            return;
        }
        stack[++index] = x;
    }
    
    public int pop() {
        if (index < 0) {
            return -1;
        }
        int ret = stack[index] + increments[index];
        if (index > 0) {
            increments[index - 1] += increments[index];
        }
        increments[index] = 0;
        --index;
        return ret;
    }
    
    public void increment(int k, int val) {
        int i = Math.min(k - 1, index);
        if (i >= 0) {
            increments[i] += val;
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.push(x);
 * int param_2 = obj.pop();
 * obj.increment(k,val);
 */
// @lc code=end

