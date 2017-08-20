import java.util.Stack;

class Solution {
    public int[] nextGreaterElements(int[] nums) {
        int[] ret = new int[nums.length];
        Stack<Integer> stack = new Stack<Integer>();
        int i, num;
        
        for (i = 0; i < nums.length; ++i)
            ret[i] = -1;
        
        for (i = 0; i < 2 * nums.length; ++i) {
            num = nums[i % nums.length];
            
            while ((! stack.isEmpty()) && nums[stack.peek()] < num) 
                ret[stack.pop()] = num;
            
            if (i < nums.length)
                stack.push(i);
        }
        
        return ret;
    }
}
