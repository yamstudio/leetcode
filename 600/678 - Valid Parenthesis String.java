import java.util.Stack;

class Solution {
    public boolean checkValidString(String s) {
        Stack<Integer> left = new Stack<>(), star = new Stack<>();
        
        for (int i = 0; i < s.length(); ++i) {
            char c = s.charAt(i);
            
            if (c == '*') {
                star.push(i);
            } else if (c == '(') {
                left.push(i);
            } else {
                if (!left.empty()) {
                    left.pop();
                } else {
                    if (star.empty()) {
                        return false;
                    }
                    star.pop();
                }
            }
        }
        
        while (!left.empty() && !star.empty()) {
            if (left.pop() > star.pop()) {
                return false;
            }
        }
        
        return left.empty();
    }
}