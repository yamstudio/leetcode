/*
 * @lc app=leetcode id=240 lang=c
 *
 * [240] Search a 2D Matrix II
 *
 * autogenerated using scripts/convert.py
 */
bool searchMatrix(int** matrix, int matrixRowSize, int matrixColSize, int target) {
    int r = matrixRowSize - 1, c = 0;
    
    if (! (matrixRowSize && matrixColSize))
        return 0;
    
    while (1) {
        if (matrix[r][c] < target)
            ++c;
        else if (matrix[r][c] == target)
            return 1;
        else
            --r;
        
        if (r < 0 || c >= matrixColSize)
            break;
    }
    return 0;
}
