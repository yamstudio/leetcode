#define swap(m, i, j, n, t1, t2)                   \
    do {                                           \
        t1 = m[j][n - 1 - i];                      \
        t2 = m[n - 1 - j][i];                      \
        m[j][n - 1 - i] = m[i][j];                 \
        m[n - 1 - j][i] = m[n - 1 - i][n - 1 - j]; \
        m[n - 1 - i][n - 1 - j] = t1;              \
        m[i][j] = t2;                              \
    } while (0)

void rotate(int** matrix, int matrixRowSize, int matrixColSize) {
    int row = 0, start = 0, end = matrixRowSize - 2, i, t1, t2;
    
    if (matrixRowSize != matrixColSize || ! matrixRowSize)
        return;
    
    while (start <= end) {
        for (i = start; i <= end; ++i)
            swap(matrix, i, row, matrixRowSize, t1, t2);
        ++start;
        --end;
        ++row;
    }
}
