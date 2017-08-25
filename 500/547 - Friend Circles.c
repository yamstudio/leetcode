static void helper(int **M, int n, int i, int *visited) {
    int j;
    
    visited[i] = 1;
    
    for (j = 0; j < n; ++j) {
        if (visited[j] || ! M[i][j])
            continue;
        helper(M, n, j, visited);
    }
}

int findCircleNum(int** M, int MRowSize, int MColSize) {
    int *visited, i, ret = 0;
    
    if (MRowSize <= 0 || MRowSize != MColSize)
        return 0;
    visited = (int *)calloc(MRowSize, sizeof(int));
    
    for (i = 0; i < MRowSize; ++i) {
        if (visited[i])
            continue;
        
        helper(M, MRowSize, i, visited);
        ++ret;
    }
    
    free(visited);
    
    return ret;
}
