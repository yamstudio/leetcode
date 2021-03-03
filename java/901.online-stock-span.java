/*
 * @lc app=leetcode id=901 lang=java
 *
 * [901] Online Stock Span
 */

// @lc code=start
class StockSpanner {

    Stack<int[]> stack;

    public StockSpanner() {
        stack = new Stack<int[]>();
    }
    
    public int next(int price) {
        int ret = 1;
        while (stack.size() > 0 && stack.peek()[0] <= price) {
            ret += stack.pop()[1];
        }
        stack.push(new int[] { price, ret });
        return ret;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.next(price);
 */
// @lc code=end

