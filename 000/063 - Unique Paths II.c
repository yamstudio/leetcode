int uniquePathsWithObstacles(int** obstacleGrid, int obstacleGridRowSize, int obstacleGridColSize) {
    int *dp, i, j, ret;
    
    dp = (int *)malloc(obstacleGridColSize * sizeof(int));
    memset(dp, 0, sizeof(int) * obstacleGridColSize);
    
    for (j = 0; j < obstacleGridColSize; ++j) {
        if (obstacleGrid[0][j] == 1) {
            dp[j] = 0;
            break;
        }
        dp[j] = 1;
    }
    
    for (i = 1; i < obstacleGridRowSize; ++i) {
        dp[0] *= ! obstacleGrid[i][0];
        for (j = 1; j < obstacleGridColSize; ++j)
            dp[j] = obstacleGrid[i][j] ? 0 : dp[j] + dp[j - 1];
    }
    
    ret = dp[obstacleGridColSize - 1];
    free(dp);
    return ret;
}
