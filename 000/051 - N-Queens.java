import java.util.ArrayList;
import java.util.Arrays;

public class Solution {
    public List<List<String>> solveNQueens(int n) {
        List<List<String>> ret = new ArrayList<List<String>>();
        List<Integer> cols = new ArrayList<Integer>();
        List<String> board = new ArrayList<String>();

        this.iterSolve(n, 0, cols, board, ret);
        
        return ret;
    }
    
    private void iterSolve(int n, int row, List<Integer> cols, List<String> board, List<List<String>> ret) {
        boolean flag;
        Integer i, j, c;
        char[] chars = new char[n];
        String line;
        
        if (row == n) {
            ret.add(new ArrayList<String>(board));
        } else  {
            for (i = 0; i < n; ++i) {
                flag = false;
                for (j = 0; j < cols.size(); ++j) {
                    c = cols.get(j);
                    if (c == i || Math.abs(row - j) == Math.abs(i - c)) {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    continue;
                Arrays.fill(chars, '.');
                chars[i] = 'Q';
                board.add(new String(chars));
                cols.add(i);
                this.iterSolve(n, row + 1, cols, board, ret);
                cols.remove(cols.size() - 1);
                board.remove(board.size() - 1);
            }
        }
    }
}
