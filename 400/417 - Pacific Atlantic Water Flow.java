import java.util.ArrayList;
import java.util.HashSet;
import java.util.Stack;

public class Solution {
    public List<int[]> pacificAtlantic(int[][] matrix) {
        List<int[]> ret = new ArrayList<int[]>();
        int rows, cols, i, j;
        int[][] oceans;
        
        if (matrix == null || (rows = matrix.length) == 0 || (cols = matrix[0].length) == 0)
            return ret;
        oceans = new int[rows][cols];
        
        for (i = 0; i < rows; ++i) {
            dfs(matrix, oceans, 0x01, i, 0, rows, cols, Integer.MIN_VALUE);
            dfs(matrix, oceans, 0x10, i, cols - 1, rows, cols, Integer.MIN_VALUE);
        }
        
        
        for (j = 0; j < cols; ++j) {
            dfs(matrix, oceans, 0x01, 0, j, rows, cols, Integer.MIN_VALUE);
            dfs(matrix, oceans, 0x10, rows - 1, j, rows, cols, Integer.MIN_VALUE);
        }
        
        for (i = 0; i < rows; ++i) {
            for (j = 0; j < cols; ++j) {
                if (oceans[i][j] == 0x11)
                    ret.add(new int[]{i, j});
            }
        }
        
        return ret;
    }
    
    private void dfs(int[][] matrix, int[][] oceans, int mask, int x, int y, int rows, int cols, int pre) {
        if (x < 0 || x >= rows || y < 0 || y >= cols || (oceans[x][y] & mask) != 0 || matrix[x][y] < pre)
            return;
        
        oceans[x][y] |= mask;
        
        dfs(matrix, oceans, mask, x - 1, y, rows, cols, matrix[x][y]);
        dfs(matrix, oceans, mask, x + 1, y, rows, cols, matrix[x][y]);
        dfs(matrix, oceans, mask, x, y - 1, rows, cols, matrix[x][y]);
        dfs(matrix, oceans, mask, x, y + 1, rows, cols, matrix[x][y]);
    }
}
