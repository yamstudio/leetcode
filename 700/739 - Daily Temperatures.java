import java.util.Stack;

class Solution {
    public int[] dailyTemperatures(int[] temperatures) {
        int len = temperatures.length;
        Stack<Integer> stack = new Stack<>();
        int[] ret = new int[len];
        
        for (int i = 0; i < len; ++i) {
            while (!stack.isEmpty() && temperatures[i] > temperatures[stack.peek()]) {
                int top = stack.pop();
                ret[top] = i - top;
            }
            
            stack.push(i);
        }
        
        return ret;
    }
}