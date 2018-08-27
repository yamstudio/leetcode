import java.util.LinkedList;
import java.util.Queue;

class Solution {
    private int[][] dirs = new int[][]{
        {-1, 0}, {1, 0}, {0, -1}, {0, 1}
    };
    
    public int[][] floodFill(int[][] image, int sr, int sc, int newColor) {
        int original = image[sr][sc];
        int rows = image.length, cols = image[0].length;
        
        if (original == newColor) {
            return image;
        }
        
        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{sr, sc});
        
        while (!queue.isEmpty()) {
            int[] curr = queue.poll();
            int row = curr[0], col = curr[1];
            image[row][col] = newColor;
            
            for (int[] dir : dirs) {
                int nrow = row + dir[0], ncol = col + dir[1];
                
                if (nrow < 0 || nrow >= rows || ncol < 0 || ncol >= cols) {
                    continue;
                }
                
                if (image[nrow][ncol] == original) {
                    queue.offer(new int[]{nrow, ncol});
                }
            }
        }
        
        return image;
    }
}