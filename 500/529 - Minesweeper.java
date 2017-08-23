class Solution {
    public char[][] updateBoard(char[][] board, int[] click) {
        int rows, cols, x, y, i, j, dx, dy, count = 0;
        
        if (board.length == 0 || board[0].length == 0)
            return board;
        rows = board.length;
        cols = board[0].length;
        x = click[0];
        y = click[1];
        
        if (board[x][y] == 'M')
            board[x][y] = 'X';
        else {
            for (i = -1; i < 2; ++i) {
                for (j = -1; j < 2; ++j) {
                    dx = x + i;
                    dy = y + j;
                    if (dx < 0 || dx >= rows || dy < 0 || dy >= cols)
                        continue;
                    if (board[dx][dy] == 'M')
                        ++count;
                }
            }
            
            if (count > 0)
                board[x][y] = (char)(count + '0');
            else {
                board[x][y] = 'B';
                
                for (i = -1; i < 2; ++i) {
                    for (j = -1; j < 2; ++j) {
                        dx = x + i;
                        dy = y + j;
                        if (dx < 0 || dx >= rows || dy < 0 || dy >= cols)
                            continue;
                        if (board[dx][dy] == 'E')
                            updateBoard(board, new int[]{dx, dy});
                    }
                }
            }
        }
        
        return board;
    }
}
