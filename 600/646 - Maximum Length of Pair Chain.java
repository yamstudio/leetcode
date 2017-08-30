import java.util.Arrays;
import java.util.Stack;

class Solution {
    public int findLongestChain(int[][] pairs) {
        Stack<int[]> stack = new Stack<int[]>();
        
        Arrays.sort(pairs, (int[] p1, int[] p2) -> (p1[1] - p2[1]));
        
        for (int[] pair : pairs) {
            if (stack.isEmpty())
                stack.push(pair);
            else {
                if (stack.peek()[1] < pair[0])
                    stack.push(pair);
            }
        }
        
        return stack.size();
    }
}
