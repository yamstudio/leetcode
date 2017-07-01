static void zero_col(int **matrix, int col, int r_size) {
    int j;

    for (j = 0; j < r_size; ++j)
        matrix[j][col] = 0;
}

void setZeroes(int** matrix, int matrixRowSize, int matrixColSize) {
    int *cols, r, c, i, *curr, c_size = matrixColSize * sizeof(int), clear_row = 0, clear_col = 0;
    
    if ((! matrix) || (! matrix[0]))
        return;
    
    for (c = 0; c < matrixColSize; ++c) {
        if (! matrix[0][c]) {
            clear_row = 1;
            break;
        }
    }
    
    for (r = 0; r < matrixRowSize; ++r) {
        if (! matrix[r][0]) {
            clear_col = 1;
            break;
        }
    }
    
    for (r = 1; r < matrixRowSize; ++r) {
        curr = matrix[r];
        for (c = 1; c < matrixColSize; ++c) {
            if (! curr[c]) {
                matrix[0][c] = 0;
                curr[0] = 0;
            }         
        }
    }
    
    for (c = 1; c < matrixColSize; ++c) {
        if (! matrix[0][c])
            zero_col(matrix, c, matrixRowSize);
    }
    
    for (r = 1; r < matrixRowSize; ++r) {
        if (! matrix[r][0])
            memset(matrix[r], 0, c_size);
    }
    
    if (clear_col)
        zero_col(matrix, 0, matrixRowSize);
    
    if (clear_row)
        memset(matrix[0], 0, c_size);
}
