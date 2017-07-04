bool searchMatrix(int** matrix, int matrixRowSize, int matrixColSize, int target) {
    int start = 0, end = matrixRowSize - 1, mid, *row = NULL;
    
    if ((! (matrixRowSize && matrixColSize)) || target < matrix[0][0])
        return 0;
    
    while (start < end - 1) {
        mid = (start + end) / 2;
        if (matrix[mid][0] < target)
            start = mid;
        else if (matrix[mid][0] > target)
            end = mid;
        else
            return 1;
    }
    
    if (target >= matrix[end][0]) {
        row = matrix[end];
    } else {
        row = matrix[start];
    }
    
    if (target > row[matrixColSize - 1]) {
        return 0;
    }
    
    start = 0;
    end = matrixColSize - 1;
    while (start < end - 1) {
        mid = (start + end) / 2;
        if (row[mid] < target)
            start = mid;
        else if (row[mid] > target)
            end = mid;
        else
            return 1;
    }

    if (row[start] == target || row[end] == target)
        return 1;
    return 0;
}
