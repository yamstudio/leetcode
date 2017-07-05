import java.util.Stack;

public class Solution {
    public int largestRectangleArea(int[] heights) {
        int[] copy;
        Stack<Integer> stack = new Stack<Integer>();
        int i, len = heights.length, c, area = 0, h;
        
        copy = new int[len + 2];
        copy[0] = -1;
        for (i = 0; i < len; ++i)
            copy[i + 1] = heights[i];
        copy[len + 1] = -1;
        len += 2;
        
        stack.push(0);
        for (i = 0; i < len; ++i) {
            c = copy[i];
            while ((! stack.empty()) && c < copy[stack.peek()]) {
                h = copy[stack.pop()];
                area = Math.max(area, h * (i - 1 - stack.peek()));
            }
            stack.push(i);
        }
        
        return area;
    }
}
