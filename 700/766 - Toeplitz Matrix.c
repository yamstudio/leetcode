bool isToeplitzMatrix(int** matrix, int matrixRowSize, int *matrixColSizes) {
    int matrixColSize = *matrixColSizes;

    for (int i = 0; i < matrixRowSize; ++i) {
        int val = matrix[i][0];
        for (int j = 1; j < matrixColSize && i + j < matrixRowSize; ++j) {
            if (val != matrix[i + j][j]) {
                return 0;
            }
        }
    }
    
    for (int j = 0; j < matrixColSize; ++j) {
        int val = matrix[0][j];
        for (int i = 1; i < matrixRowSize && i + j < matrixColSize; ++i) {
            if (val != matrix[i][i + j]) {
                return 0;
            }
        }
    }
    
    return 1;
}