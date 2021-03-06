/*
 * @lc app=leetcode id=498 lang=c
 *
 * [498] Diagonal Traverse
 *
 * autogenerated using scripts/convert.py
 */
/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* findDiagonalOrder(int** matrix, int matrixRowSize, int matrixColSize, int* returnSize) {
    int *ret, size = matrixRowSize * matrixColSize, i, dirs[] = {-1, 1, 1, -1}, r = 0, c = 0, s = 0;
    
    if (! size)
        return NULL;
    
    ret = (int *)malloc(size * sizeof(int));
    
    for (i = 0; i < size; ++i) {
        ret[i] = matrix[r][c];
        r += dirs[2 * s];
        c += dirs[2 * s + 1];
        
        if (r >= matrixRowSize) {
            r = matrixRowSize - 1;
            c += 2;
            s = 1 - s;
        }
        
        if (c >= matrixColSize) {
            c = matrixColSize - 1;
            r += 2;
            s = 1 - s;
        }
        
        if (r < 0) {
            r = 0;
            s = 1 - s;
        }
        
        if (c < 0) {
            c = 0;
            s = 1 - s;
        }
    }
    
    *returnSize = size;
    return ret;
}
