static void helper(char **grid, int gridRowSize, int gridColSize, int x, int y, int **visited) {
    if (x < 0 || x >= gridRowSize || y < 0 || y >= gridColSize)
        return;
    
    if (grid[x][y] == '0' || visited[x][y])
        return;
    
    visited[x][y] = 1;
    
    helper(grid, gridRowSize, gridColSize, x - 1, y, visited);
    helper(grid, gridRowSize, gridColSize, x + 1, y, visited);
    helper(grid, gridRowSize, gridColSize, x, y - 1, visited);
    helper(grid, gridRowSize, gridColSize, x, y + 1, visited);
}

int numIslands(char** grid, int gridRowSize, int gridColSize) {
    int ret = 0, i, j, *temp, **visited;
    
    temp = (int *)calloc(gridRowSize * gridColSize, sizeof(int));
    visited = (int **)malloc(gridRowSize * sizeof(int *));
    for (i = 0; i < gridRowSize; ++i)
        visited[i] = temp + i * gridColSize;
    
    for (i = 0; i < gridRowSize; ++i) {
        for (j = 0; j < gridColSize; ++j) {
            if (grid[i][j] == '1' && ! visited[i][j]) {
                helper(grid, gridRowSize, gridColSize, i, j, visited);
                ++ret;
            }
        }
    }

    free(temp);
    free(visited);
    
    return ret;
}
