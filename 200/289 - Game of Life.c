void gameOfLife(int** board, int boardRowSize, int boardColSize) {
    int r, c, i, x, y, count;
    int r_range[] = {-1, -1, -1, 0, 0, 1, 1, 1};
    int c_range[] = {-1, 0, 1, -1, 1, -1, 0, 1};
    
    if (! (boardRowSize && boardColSize))
        return;
    
    for (r = 0; r < boardRowSize; ++r) {
        for (c = 0; c < boardColSize; ++c) {
            count = 0;
            
            for (i = 0; i < 8; ++i) {
                x = r + r_range[i];
                y = c + c_range[i];
                
                if (x >= 0 && x < boardRowSize && y >= 0 && y < boardColSize && (board[x][y] == 1 || board[x][y] == 2))
                    ++count;
            }
            
            if (board[r][c] && (count < 2 || count > 3))
                board[r][c] = 2;
            else if (count == 3 && ! board[r][c])
                board[r][c] = 3;
        }
    }
    
    for (r = 0; r < boardRowSize; ++r) {
        for (c = 0; c < boardColSize; ++c)
            board[r][c] %= 2;
    }
}
