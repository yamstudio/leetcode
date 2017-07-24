import java.util.Stack;

public class Solution {
    public int calculate(String s) {
        Stack<Integer> stack = new Stack<Integer>();
        int i, ret = 0, sign = 1, temp;
        char c = ' ';
        
        for (i = 0; i < s.length(); ++i) {
            while (i < s.length() && (c = s.charAt(i)) == ' ')
                ++i;
            if (i == s.length())
                break;
            
            if (c == '+')
                sign = 1;
            else if (c == '-')
                sign = -1;
            else if (c == '(') {
                stack.push(ret);
                stack.push(sign);
                ret = 0;
                sign = 1;
            } else if (c == ')') {
                ret = stack.pop() * ret + stack.pop();
                sign = 1;
            } else {
                temp = (int)(c - '0');
                while (i < s.length() - 1 && Character.isDigit(s.charAt(i + 1))) {
                    i++;
                    temp *= 10;
                    temp += (int)(s.charAt(i) - '0');
                }
                ret += sign * temp;
            }
        }
        
        return ret;
    }
}
