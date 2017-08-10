int countBattleships(char** board, int boardRowSize, int boardColSize) {
    int ret = 0, i, j;
    
    for (i = 0; i < boardRowSize; ++i) {
        for (j = 0; j < boardColSize; ++j) {
            if (board[i][j] == '.' || (i > 0 && board[i - 1][j] == 'X') || (j > 0 && board[i][j - 1] == 'X'))
                continue;
            ++ret;
        }
    }
    
    return ret;
}
