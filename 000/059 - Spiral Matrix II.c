/**
 * Return an array of arrays.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int** generateMatrix(int n) {
    int **ret, i, j, times = (n + 1) / 2, m = 1, bound, off;
    
    ret = (int **)malloc(n * sizeof(int *));
    for (i = 0; i < n; ++i) {
        ret[i] = malloc(n * sizeof(int));
    }
    
    for (i = 0; i < times; ++i) {
        bound = n - 1 - i;
        off = bound - i;
        if (i == bound) {
            ret[i][i] = m;
            break;
        }
        for (j = i; j < bound; ++j) {
            ret[j][bound] = m + off;
            ret[i][j] = m++;
        }
        m += off;
        for (j = bound; j > i; --j) {
            ret[j][i] = m + off;
            ret[bound][j] = m++;
        }
        m += off;
    }
    
    return ret;
}
