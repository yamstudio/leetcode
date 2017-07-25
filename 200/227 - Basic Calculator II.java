import java.util.Stack;

public class Solution {
    public int calculate(String s) {
        Stack<Integer> stack = new Stack<Integer>();
        int ret = 0, num = 0, i;
        char c = ' ', op = '+';
        
        for (i = 0; i < s.length(); ++i) {
            
            c = s.charAt(i);
            
            if (Character.isDigit(c)) {
                num = num * 10 + (int)(c - '0');  
            }
            
            if (i == s.length() - 1 || (c != ' ' && ! Character.isDigit(c))) {
                switch (op) {
                    case '+':
                        stack.push(num);
                        break;
                    case '-':
                        stack.push(-num);
                        break;
                    case '*':
                        stack.push(stack.pop() * num);
                        break;
                    default:
                        stack.push(stack.pop() / num);
                        break;
                }
                
                op = c;
                num = 0;
            }
        }
        
        while (! stack.empty())
            ret += stack.pop();
        
        return ret;
    }
}
