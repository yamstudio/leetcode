bool isValidSudoku(char** board, int boardRowSize, int boardColSize) {
    int i, j, k, l, d;
    short r_count, c_count;
    
    if (boardRowSize != 9 || boardColSize != 9)
        return 0;

    for (i = 0; i < 9; ++i) {
        r_count = 0;
        c_count = 0;
        for (j = 0; j < 9; ++j) {
            if ((d = board[i][j] - '1') >= 0) {
                if (r_count & (1 << d))
                    return 0;
                else
                    r_count |= 1 << d;
            }
            if ((d = board[j][i] - '1') >= 0) {
                if (c_count & (1 << d))
                    return 0;
                else
                    c_count |= 1 << d;
            }
        }
    }
    
    for (i = 0; i < 9; i += 3) {
        for (j = 0; j < 9; j += 3) {
            r_count = 0;
            for (k = 0; k < 3; ++k) {
                for (l = 0; l < 3; ++l) {
                    if ((d = board[i + k][j + l] - '1') >= 0) {
                        if (r_count & (1 << d))
                            return 0;
                        else
                            r_count |= 1 << d;
                    }
                }
            }
        }
    }
    
    return 1;
}
