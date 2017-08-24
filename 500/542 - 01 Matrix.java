import java.util.Queue;
import java.util.LinkedList;

class Solution {
    public int[][] updateMatrix(int[][] matrix) {
        Queue<Integer> queue = new LinkedList<Integer>();
        int rows = matrix.length, cols = matrix[0].length, x, y, dx, dy;
        int[][] dirs = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}};
        
        for (x = 0; x < rows; ++x) {
            for (y = 0; y < cols; ++y) {
                if (matrix[x][y] == 0)
                    queue.add(x * 100000 + y);
                else
                    matrix[x][y] = Integer.MAX_VALUE;
            }
        }
        
        while (! queue.isEmpty()) {
            x = queue.poll();
            y = x % 100000;
            x /= 100000;
            
            for (int[] dir : dirs) {
                dx = x + dir[0];
                dy = y + dir[1];
                
                if (dx < 0 || dx >= rows || dy < 0 || dy >= cols || matrix[dx][dy] <= matrix[x][y])
                    continue;
                matrix[dx][dy] = matrix[x][y] + 1;
                queue.add(dx * 100000 + dy);
            }
        }
        
        return matrix;
    }
}
