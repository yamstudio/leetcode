import java.util.Stack;

public class Solution {
    public int evalRPN(String[] tokens) {
        Stack<Integer> stack = new Stack<Integer>();
        int temp1, temp2;
        
        for (String s : tokens) {
            switch (s) {
                case "+":
                    stack.push(stack.pop() + stack.pop());
                    break;
                case "-":
                    stack.push(-stack.pop() + stack.pop());
                    break;
                case "*":
                    stack.push(stack.pop() * stack.pop());
                    break;
                case "/":
                    temp1 = stack.pop();
                    temp2 = stack.pop();
                    stack.push(temp2 / temp1);
                    break;
                default:
                    stack.push(Integer.parseInt(s));
            }
        }
        
        return stack.pop();
    }
}
